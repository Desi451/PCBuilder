using Application.DTO.Computer;
using Domain.Entities.Computer;

namespace Application.Service.Compatibility;

public class ComputerBuild
{
    public required int CaseId { get; init; }
    public required int CpuId { get; init; }
    public required int MotherboardId { get; init; }
    public required int RamMemoryId { get; init; }
    public required int PsuId { get; init; }
    public int? GpuId { get; init; }
    public required List<int> HddIds { get; init; }
    public required List<int> SsdIds { get; init; }

    public static ComputerBuild From(AddComputerDTO pc)
    {
        return new ComputerBuild
        {
            CaseId = pc.CaseId,
            CpuId = pc.CpuId,
            MotherboardId = pc.MotherboardId,
            RamMemoryId = pc.RamMemoryId,
            PsuId = pc.PsuId,
            GpuId = pc.GpuId,
            HddIds = pc.Drives?.Select(drive => drive.Id).ToList() ?? [],
            SsdIds = pc.Ssds?.Select(drive => drive.Id).ToList() ?? []
        };
    }

    public static ComputerBuild From(ComputerDTO pc)
    {
        return new ComputerBuild
        {
            CaseId = pc.CaseId,
            CpuId = pc.CpuId,
            MotherboardId = pc.MotherboardId,
            RamMemoryId = pc.RamMemoryId,
            PsuId = pc.PsuId,
            GpuId = pc.GpuId,
            HddIds = pc.Drives?.Select(drive => drive.Id).ToList() ?? [],
            SsdIds = pc.Ssds?.Select(drive => drive.Id).ToList() ?? []
        };
    }

    public static ComputerBuild From(Computer computer, List<int> hddIds, List<int> ssdIds)
    {
        return new ComputerBuild
        {
            CaseId = computer.CaseId,
            CpuId = computer.CpuId,
            MotherboardId = computer.MotherboardId,
            RamMemoryId = computer.RamMemoryId,
            PsuId = computer.PsuId,
            GpuId = computer.GpuId,
            HddIds = hddIds,
            SsdIds = ssdIds
        };
    }
}
