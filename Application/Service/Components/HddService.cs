using Application.DTO.Components.Drive;
using Application.Interfaces.Components;
using AutoMapper;
using Domain.Entities.Components.Drives;
using Domain.Interfaces.Common;
using Domain.Interfaces.Repository.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.Components;

public class HddService : IHddService
{
    private IHddRepository _repository;
    private readonly ISaveData _saveData;
    private readonly IMapper _mapper;

    public HddService(
        IHddRepository repository,
        ISaveData saveData,
        IMapper mapper)
    {
        _repository = repository;
        _saveData = saveData;
        _mapper = mapper;
    }

    public async Task<HddDTO> Add(AddHddDTO ssd)
    {
        var res = _mapper.Map<Hdd>(ssd);
        await _repository.Add(res);
        await _saveData.Save();
        return _mapper.Map<HddDTO>(res);
    }

    public async Task Delete(int id)
    {
        await _repository.Delete(id);
        await _saveData.Save();
    }

    public async Task<List<HddDTO>> GetAll()
    {
        var res = await _repository.GetHdds();
        return _mapper.Map<List<HddDTO>>(res);
    }

    public async Task<HddDTO> GetById(int id)
    {
        var res = await _repository.GetById(id);
        return _mapper.Map<HddDTO>(res);
    }

    public async Task Update(HddDTO ssd)
    {
        try
        {
            var res = _mapper.Map<Hdd>(ssd);
            await _repository.Update(res);
            await _saveData.Save();
        }
        catch
        {
            throw;
        }
    }
}
