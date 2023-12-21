using Application.DTO.BrandDTOs;
using Application.DTO.Components.Drive;
using Application.Interfaces.Components;
using AutoMapper;
using Domain.Entities;
using Domain.Entities.Components.Drives;
using Domain.Interfaces.Common;
using Domain.Interfaces.Repository.Components;

namespace Application.Service.Components;

public class SsdService : ISsdService
{
    private ISsdRepository _repository;
    private readonly ISaveData _saveData;
    private readonly IMapper _mapper;

    public SsdService(
        ISsdRepository repository,
        ISaveData saveData,
        IMapper mapper)
    {
        _repository = repository;
        _saveData = saveData;
        _mapper = mapper;
    }
    public async Task<SsdDTO> Add(AddSsdDTO ssd)
    {
        var res = _mapper.Map<Ssd>(ssd);
        await _repository.Add(res);
        await _saveData.Save();
        return _mapper.Map<SsdDTO>(res);
    }

    public async Task Delete(int id)
    {
        await _repository.Delete(id);
        await _saveData.Save();
    }

    public async Task<List<SsdDTO>> GetAll()
    {
        var res = await _repository.GetSsds();
        return _mapper.Map<List<SsdDTO>>(res);
    }

    public async Task<SsdDTO> GetById(int id)
    {
        var res = await _repository.GetById(id);
        return _mapper.Map<SsdDTO>(res);
    }

    public async Task Update(SsdDTO ssd)
    {
        try
        {
            var res = _mapper.Map<Ssd>(ssd);
            await _repository.Update(res);
            await _saveData.Save();
        }
        catch
        {
            throw;
        }
    }
}
