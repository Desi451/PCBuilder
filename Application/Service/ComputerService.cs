using Application.DTO.BrandDTOs;
using Application.DTO.Components.Case_Size;
using Application.DTO.Components.CPU;
using Application.DTO.Components.Motherboard;
using Application.DTO.Components.PowerSupllyDTOs;
using Application.DTO.Components.RAM;
using Application.DTO.Computer;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities.Components.Drives;
using Domain.Entities.Computer;
using Domain.Interfaces.Common;
using Domain.Interfaces.Repository;

namespace Application.Service;

public class ComputerService : IComputerService
{
    private IComputerRepository _repository;
    private IBrandRepository _brandRepository;
    private ISeriesRepository _seriesRepository;
    private readonly ISaveData _saveData;
    private readonly IMapper _mapper;

    public ComputerService(
        IComputerRepository repository,
        ISeriesRepository seriesRepository,
        IBrandRepository brandRepository,
        ISaveData saveData,
        IMapper mapper)
    {
        _brandRepository = brandRepository;
        _seriesRepository = seriesRepository;
        _repository = repository;
        _saveData = saveData;
        _mapper = mapper;
    }

    public async Task Add(AddComputerDTO pc)
    {
        var res = _mapper.Map<Computer>(pc);
        var hdds = _mapper.Map<List<Hdd>>(pc.Drives);
        var ssds = _mapper.Map<List<Ssd>>(pc.Ssds);
        await _repository.Add(res, hdds, ssds);
        await _saveData.Save();
    }

    public async Task Delete(int id)
    {
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
        try
        {
            var res = _mapper.Map<Computer>(pc);
            var hdds = _mapper.Map<List<Hdd>>(pc.Drives);
            var ssds = _mapper.Map<List<Ssd>>(pc.Ssds);
            await _repository.Update(res, hdds, ssds);
            await _saveData.Save();
        }
        catch
        {
            throw;
        }
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

    public async Task<List<PowerSupplyDTO>> GetPsuByWattage(int wattage)
    {
        var res = await _repository.GetPsusByWattage(wattage);
        return _mapper.Map<List<PowerSupplyDTO>>(res);
    }

    public async Task<List<CaseDTO>> GetCasesByStandard(int caseSizeId, double gpuLength)
    {
        var res = await _repository.GetCasesBySize(caseSizeId, gpuLength);
        return _mapper.Map<List<CaseDTO>>(res);
    }

    public async Task<ComputerFormDTO> GetFullDataById(int id)
    {
        var pc = await _repository.GetFullDataById(id);
        var res = _mapper.Map<ComputerFormDTO>(pc);
        var series = await _seriesRepository.GetById(res.Cpu.SeriesId);
        var cpuBrand = await _brandRepository.GetById(series.BrandId);
        res.cpuBrand = _mapper.Map<BrandDTO>(cpuBrand);
        return _mapper.Map<ComputerFormDTO>(res);
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
}
