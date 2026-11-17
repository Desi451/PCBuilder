using Application.Interfaces;
using Application.Service.Common;
using Domain.Common;
using Domain.Entities.Components;
using Domain.Entities.Components.Case;
using Domain.Entities.Components.CPU;
using Domain.Entities.Components.GPU;
using Domain.Entities.Components.Motherboard;
using Domain.Entities.Components.RamMemory;
using Domain.Interfaces.Repository;

namespace Application.Service.Compatibility;

public class ComputerCompatibilityValidator : IComputerCompatibilityValidator
{
    private const string HddKind = "HDD";
    private const string SsdKind = "SSD";

    private readonly IComputerRepository _repository;

    public ComputerCompatibilityValidator(IComputerRepository repository)
    {
        _repository = repository;
    }

    public async Task EnsureCompatible(ComputerBuild build, ComputerBuild? current)
    {
        var violations = await Validate(build, current);
        if (violations.Count > 0)
        {
            throw new CompatibilityException(violations);
        }
    }

    public async Task<List<CompatibilityViolation>> Validate(ComputerBuild build, ComputerBuild? current)
    {
        var violations = new List<CompatibilityViolation>();

        var pcCase = Available(await _repository.FindCase(build.CaseId), c => c.Name, "Case", build.CaseId, current?.CaseId, violations);
        var cpu = Available(await _repository.FindCpu(build.CpuId), c => c.Name, "Processor", build.CpuId, current?.CpuId, violations);
        var motherboard = Available(await _repository.FindMotherboard(build.MotherboardId), m => m.Name, "Motherboard", build.MotherboardId, current?.MotherboardId, violations);
        var ram = Available(await _repository.FindRam(build.RamMemoryId), r => r.Name, "RAM", build.RamMemoryId, current?.RamMemoryId, violations);
        var psu = Available(await _repository.FindPsu(build.PsuId), p => p.Name, "Power supply", build.PsuId, current?.PsuId, violations);
        GPU? gpu = null;
        if (build.GpuId is not null)
        {
            gpu = Available(await _repository.FindGpu(build.GpuId.Value), g => g.Name, "Graphics card", build.GpuId.Value, current?.GpuId, violations);
        }

        var drives = await LoadDrives(build, current, violations);

        CheckDuplicateDrives(build.HddIds, HddKind, violations);
        CheckDuplicateDrives(build.SsdIds, SsdKind, violations);
        CheckSocket(cpu, motherboard, violations);
        CheckRam(ram, motherboard, cpu, violations);
        CheckCase(pcCase, motherboard, psu, gpu, violations);
        CheckPower(psu, cpu, gpu, build.GpuId, violations);
        CheckGpuPresence(cpu, build.GpuId, violations);
        CheckDrives(drives, motherboard, violations);

        return violations;
    }

    private static T? Available<T>(T? component, Func<T, string> name, string label, int id, int? currentId, List<CompatibilityViolation> violations)
        where T : AuditableEntity
    {
        if (component is null)
        {
            violations.Add(new(CompatibilityRuleNames.ComponentExists, $"{label} with ID = {id} does not exist."));
            return null;
        }

        if (component.IsDeleted && id != currentId)
        {
            violations.Add(new(CompatibilityRuleNames.ComponentExists, $"{label} '{name(component)}' has been removed from the catalog and cannot be selected."));
            return null;
        }

        return component;
    }

    private async Task<List<DriveInfo>> LoadDrives(ComputerBuild build, ComputerBuild? current, List<CompatibilityViolation> violations)
    {
        var hddIds = build.HddIds.Distinct().ToList();
        var ssdIds = build.SsdIds.Distinct().ToList();

        var hdds = (await _repository.FindHdds(hddIds))
            .Select(hdd => new DriveInfo(HddKind, hdd.Id, hdd.Name, hdd.Slot?.Name, hdd.IsDeleted))
            .ToList();
        var ssds = (await _repository.FindSsds(ssdIds))
            .Select(ssd => new DriveInfo(SsdKind, ssd.Id, ssd.Name, ssd.Slot?.Name, ssd.IsDeleted))
            .ToList();

        var available = new List<DriveInfo>();
        AddAvailableDrives(HddKind, hddIds, hdds, current?.HddIds ?? [], available, violations);
        AddAvailableDrives(SsdKind, ssdIds, ssds, current?.SsdIds ?? [], available, violations);
        return available;
    }

    private static void AddAvailableDrives(
        string kind,
        List<int> requestedIds,
        List<DriveInfo> loaded,
        List<int> currentIds,
        List<DriveInfo> available,
        List<CompatibilityViolation> violations)
    {
        foreach (var id in requestedIds)
        {
            var drive = loaded.FirstOrDefault(d => d.Id == id);
            if (drive is null)
            {
                violations.Add(new(CompatibilityRuleNames.ComponentExists, $"{kind} with ID = {id} does not exist."));
                continue;
            }

            if (drive.IsDeleted && !currentIds.Contains(id))
            {
                violations.Add(new(CompatibilityRuleNames.ComponentExists, $"{kind} '{drive.Name}' has been removed from the catalog and cannot be selected."));
                continue;
            }

            available.Add(drive);
        }
    }

    private static void CheckDuplicateDrives(List<int> ids, string kind, List<CompatibilityViolation> violations)
    {
        var duplicates = ids.GroupBy(id => id).Where(group => group.Count() > 1).Select(group => group.Key).ToList();
        foreach (var id in duplicates)
        {
            violations.Add(new(CompatibilityRuleNames.DuplicateDrive, $"{kind} with ID = {id} is selected more than once."));
        }
    }

    private static void CheckSocket(CPU? cpu, Motherboard? motherboard, List<CompatibilityViolation> violations)
    {
        if (cpu is null || motherboard is null)
        {
            return;
        }

        if (cpu.SocketCpuId != motherboard.SocketCpuId)
        {
            violations.Add(new(CompatibilityRuleNames.CpuSocket, $"Processor '{cpu.Name}' does not fit the socket of motherboard '{motherboard.Name}'."));
        }
    }

    private static void CheckRam(RamMemories? ram, Motherboard? motherboard, CPU? cpu, List<CompatibilityViolation> violations)
    {
        if (ram is null)
        {
            return;
        }

        if (motherboard is not null)
        {
            if (!motherboard.Memories.Any(memory => memory.MemoryId == ram.MemorySpeedId))
            {
                violations.Add(new(CompatibilityRuleNames.RamSupported, $"Motherboard '{motherboard.Name}' does not support the memory type and speed of '{ram.Name}'."));
            }

            if (ram.Capacity > motherboard.MaxMemory)
            {
                violations.Add(new(CompatibilityRuleNames.RamCapacity, $"RAM capacity {ram.Capacity} GB exceeds the motherboard limit of {motherboard.MaxMemory} GB."));
            }

            if (ram.NoELements > motherboard.RamSlots)
            {
                violations.Add(new(CompatibilityRuleNames.RamSlots, $"RAM kit '{ram.Name}' has {ram.NoELements} modules but motherboard '{motherboard.Name}' has only {motherboard.RamSlots} slots."));
            }
        }

        if (cpu is not null && ram.Capacity > cpu.MaxRam)
        {
            violations.Add(new(CompatibilityRuleNames.RamCapacity, $"RAM capacity {ram.Capacity} GB exceeds the processor limit of {cpu.MaxRam} GB."));
        }
    }

    private static void CheckCase(Case? pcCase, Motherboard? motherboard, PowerSupply? psu, GPU? gpu, List<CompatibilityViolation> violations)
    {
        CaseSize? psuSize = null;
        if (psu is not null)
        {
            psuSize = CompatibilityRules.ParsePsuFormFactor(psu.standard);
            if (psuSize is null)
            {
                violations.Add(new(CompatibilityRuleNames.PsuFormFactor, $"Power supply '{psu.Name}' has an unknown form factor '{psu.standard}'. Expected one of: EATX, ATX, ITXMicroATX, ITX, SFX."));
            }
        }

        if (pcCase is null)
        {
            return;
        }

        if (motherboard is not null && !CompatibilityRules.CaseFits(pcCase.CaseSize, motherboard.CaseSize))
        {
            violations.Add(new(CompatibilityRuleNames.CaseFormFactor, $"Motherboard '{motherboard.Name}' ({motherboard.CaseSize}) does not fit case '{pcCase.Name}' ({pcCase.CaseSize})."));
        }

        if (psu is not null && psuSize is not null && !CompatibilityRules.CaseFits(pcCase.CaseSize, psuSize.Value))
        {
            violations.Add(new(CompatibilityRuleNames.CaseFormFactor, $"Power supply '{psu.Name}' ({psu.standard}) does not fit case '{pcCase.Name}' ({pcCase.CaseSize})."));
        }

        if (gpu is not null && CompatibilityRules.RequiredCaseDepth(gpu.Length) > pcCase.Deepth)
        {
            violations.Add(new(CompatibilityRuleNames.GpuClearance, $"Graphics card '{gpu.Name}' ({gpu.Length} mm) needs {CompatibilityRules.GpuClearanceMm} mm of clearance, but case '{pcCase.Name}' is only {pcCase.Deepth} mm deep."));
        }
    }

    private static void CheckPower(PowerSupply? psu, CPU? cpu, GPU? gpu, int? gpuId, List<CompatibilityViolation> violations)
    {
        if (psu is null || cpu is null || (gpuId is not null && gpu is null))
        {
            return;
        }

        var required = CompatibilityRules.RequiredPsuPower(cpu.TDP, gpu?.TDP);
        if (psu.Power < required)
        {
            violations.Add(new(CompatibilityRuleNames.PsuPower, $"Power supply '{psu.Name}' delivers {psu.Power} W, but this configuration needs at least {required} W."));
        }
    }

    private static void CheckGpuPresence(CPU? cpu, int? gpuId, List<CompatibilityViolation> violations)
    {
        if (cpu is null || gpuId is not null)
        {
            return;
        }

        if (!cpu.IsAPU)
        {
            violations.Add(new(CompatibilityRuleNames.GpuRequired, $"Processor '{cpu.Name}' has no integrated graphics, so a graphics card is required."));
        }
    }

    private static void CheckDrives(List<DriveInfo> drives, Motherboard? motherboard, List<CompatibilityViolation> violations)
    {
        var m2Count = 0;
        var sataCount = 0;

        foreach (var drive in drives)
        {
            var slotType = CompatibilityRules.ClassifyDriveSlot(drive.SlotName);
            if (slotType == DriveSlotType.M2)
            {
                m2Count++;
            }
            else if (slotType == DriveSlotType.Sata)
            {
                sataCount++;
            }
            else
            {
                violations.Add(new(CompatibilityRuleNames.DriveInterface, $"{drive.Kind} '{drive.Name}' uses an unsupported interface '{drive.SlotName}'. Only M.2 and SATA drives are supported."));
            }
        }

        if (motherboard is null)
        {
            return;
        }

        if (m2Count > motherboard.M2Slots)
        {
            violations.Add(new(CompatibilityRuleNames.DriveSlots, $"{m2Count} M.2 drives selected, but motherboard '{motherboard.Name}' has only {motherboard.M2Slots} M.2 slots."));
        }

        if (sataCount > motherboard.SATASlots)
        {
            violations.Add(new(CompatibilityRuleNames.DriveSlots, $"{sataCount} SATA drives selected, but motherboard '{motherboard.Name}' has only {motherboard.SATASlots} SATA ports."));
        }
    }

    private sealed record DriveInfo(string Kind, int Id, string Name, string? SlotName, bool IsDeleted);
}
