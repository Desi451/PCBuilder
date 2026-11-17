using Application.DTO.BrandDTOs;
using Application.DTO.Components.Case_Size;
using Application.DTO.Components.CPU;
using Application.DTO.Components.Motherboard;
using Application.DTO.Components.PowerSupllyDTOs;
using Application.DTO.Components.RAM;
using Application.DTO.Computer;
using Application.Interfaces;
using Application.Service.Common;
using Application.Service.Compatibility;
using AutoMapper;
using Domain.Entities.Components.Drives;
using Domain.Entities.Computer;
using Domain.Interfaces.Common;
using Domain.Interfaces.Repository;

namespace Application.Service;

public class ComputerService : IComputerService
{
    private IComputerRepository _repository;
    private readonly ISaveData _saveData;
    private readonly IMapper _mapper;
    private readonly ICurrentUser _currentUser;
    private readonly IComputerCompatibilityValidator _validator;

    public ComputerService(
        IComputerRepository repository,
        ISaveData saveData,
        IMapper mapper,
        ICurrentUser currentUser,
        IComputerCompatibilityValidator validator)
    {
        _currentUser = currentUser;
        _validator = validator;
        _repository = repository;
        _saveData = saveData;
        _mapper = mapper;
    }

    public async Task Add(AddComputerDTO pc)
    {
        await _validator.EnsureCompatible(ComputerBuild.From(pc), null);

        var res = _mapper.Map<Computer>(pc);
        res.UserId = _currentUser.Id;
        var hdds = _mapper.Map<List<Hdd>>(pc.Drives);
        var ssds = _mapper.Map<List<Ssd>>(pc.Ssds);
        await _repository.Add(res, hdds, ssds);
        await _saveData.Save();
    }

    public async Task Delete(int id)
    {
        await GetOwnedComputer(id);
        await _repository.Delete(id);
        await _saveData.Save();
    }

    public async Task<ComputerDTO> GetById(int id)
    {
        var res = await _repository.GetById(id);
        return _mapper.Map<ComputerDTO>(res);
    }

    public async Task<List<ComputerDTO>> GetComputers()
    {
        var res = await _repository.GetComputers();
        return _mapper.Map<List<ComputerDTO>>(res);
    }

    public async Task Update(ComputerDTO pc)
    {
        var existing = await GetOwnedComputer(pc.Id);
        var current = ComputerBuild.From(existing, await _repository.GetHddIds(pc.Id), await _repository.GetSsdIds(pc.Id));
        await _validator.EnsureCompatible(ComputerBuild.From(pc), current);

        var res = _mapper.Map<Computer>(pc);
        var hdds = _mapper.Map<List<Hdd>>(pc.Drives);
        var ssds = _mapper.Map<List<Ssd>>(pc.Ssds);
        await _repository.Update(res, hdds, ssds);
        await _saveData.Save();
    }

    public async Task<List<BrandDTO>> GetCpuBrands()
    {
        var res = await _repository.GetBrandsForCPUSocketsAsync();
        return _mapper.Map<List<BrandDTO>>(res);
    }

    public async Task<List<CpuDTO>> GetCPUsByBrandId(int brandId)
    {
        var res = await _repository.GetCPUsByBrandIdAsync(brandId);
        return _mapper.Map<List<CpuDTO>>(res);
    }

    public async Task<List<MotherboardDTO>> GetMotherBoardsBySocket(int socketId)
    {
        var res = await _repository.GetMotherBoardsBySocket(socketId);
        return _mapper.Map<List<MotherboardDTO>>(res);
    }

    public async Task<List<RamDTO>> GetRamsByMotherboard(int motherboardId)
    {
        var res = await _repository.GetRamsByMotherboard(motherboardId);
        return _mapper.Map<List<RamDTO>>(res);
    }

    public async Task<List<CompatibilityViolation>> Validate(AddComputerDTO pc)
    {
        return await _validator.Validate(ComputerBuild.From(pc), null);
    }

    public async Task<List<PowerSupplyDTO>> GetPsusForBuild(int cpuId, int? gpuId)
    {
        var cpu = await _repository.FindCpu(cpuId) ?? throw new NotFoundException($"No processor with ID = {cpuId}");
        int? gpuTdp = null;
        if (gpuId is not null)
        {
            var gpu = await _repository.FindGpu(gpuId.Value) ?? throw new NotFoundException($"No graphics card with ID = {gpuId}");
            gpuTdp = gpu.TDP;
        }

        var res = await _repository.GetPsusByWattage(CompatibilityRules.RequiredPsuPower(cpu.TDP, gpuTdp));
        return _mapper.Map<List<PowerSupplyDTO>>(res);
    }

    public async Task<List<CaseDTO>> GetCasesForBuild(CaseRequest request)
    {
        var motherboard = await _repository.FindMotherboard(request.MotherboardId) ?? throw new NotFoundException($"No motherboard with ID = {request.MotherboardId}");
        var psu = await _repository.FindPsu(request.PsuId) ?? throw new NotFoundException($"No power supply with ID = {request.PsuId}");
        int? gpuLength = null;
        if (request.GpuId is not null)
        {
            var gpu = await _repository.FindGpu(request.GpuId.Value) ?? throw new NotFoundException($"No graphics card with ID = {request.GpuId}");
            gpuLength = gpu.Length;
        }

        var maxCaseSize = motherboard.CaseSize;
        var psuSize = CompatibilityRules.ParsePsuFormFactor(psu.standard);
        if (psuSize is not null)
        {
            maxCaseSize = CompatibilityRules.LargestFormFactor(maxCaseSize, psuSize.Value);
        }

        var res = await _repository.GetCasesBySize(maxCaseSize, CompatibilityRules.RequiredCaseDepth(gpuLength));
        return _mapper.Map<List<CaseDTO>>(res);
    }

    public async Task<ComputerFormDTO> GetFullDataById(int id)
    {
        var pc = await _repository.GetFullDataById(id) ?? throw new NotFoundException($"No computer with ID = {id}");
        var res = _mapper.Map<ComputerFormDTO>(pc);
        res.cpuBrand = _mapper.Map<BrandDTO>(pc.Cpu.Series.Brand);
        return res;
    }

    public async Task<List<ComputerViewDTO>> GetComputersView()
    {
        var pc = await _repository.GetComputersView();
        List<ComputerViewDTO> res= new List<ComputerViewDTO>();
        foreach (var item in pc)
        {
            ComputerViewDTO i = new ComputerViewDTO();
            i.Id = item.Id;
            i.Cpu = item.Cpu.Name;
            i.Name = item.Name;
            i.Ram = item.RamMemory.Capacity.ToString() + " GB";
            res.Add(i);
        }

        return res;
    }

    public async Task<List<ComputerViewDTO>> GetComputersViewByUser(int id)
    {
        var pc = await _repository.GetComputersViewByUser(id);
        List<ComputerViewDTO> res = new List<ComputerViewDTO>();
        foreach (var item in pc)
        {
            ComputerViewDTO i = new ComputerViewDTO();
            i.Id = item.Id;
            i.Cpu = item.Cpu.Name;
            i.Name = item.Name;
            i.Ram = item.RamMemory.Capacity.ToString() + " GB";
            res.Add(i);
        }

        return res;
    }

    private async Task<Computer> GetOwnedComputer(int id)
    {
        var computer = await _repository.GetById(id);
        if (computer is null || computer.IsDeleted)
        {
            throw new NotFoundException($"No computer with ID = {id}");
        }

        if (computer.UserId != _currentUser.Id && !_currentUser.IsAdminOrAbove)
        {
            throw new ForbiddenException("You can only modify your own computers.");
        }

        return computer;
    }
}
