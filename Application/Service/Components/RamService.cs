using Application.DTO.Components.Case_Size;
using Application.DTO.Components.CPU;
using Application.DTO.Components.RAM;
using Application.Interfaces.Components;
using AutoMapper;
using Domain.Entities.Components.Case;
using Domain.Entities.Components.RamMemory;
using Domain.Interfaces.Common;
using Domain.Interfaces.Repository.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.Components;

public class RamService : IRAMService
{
    private IRamRepository _repo;
    private readonly ISaveData _saveData;
    private readonly IMapper _mapper;

    public RamService(IRamRepository repo, ISaveData saveData, IMapper mapper)
    {
        _repo = repo;
        _saveData = saveData;
        _mapper = mapper;
    }

    public async  Task<RamDTO> Add(AddRamDTO post)
    {
        var res = _mapper.Map<RamMemories>(post);
        await _repo.Add(res);
        await _saveData.Save();
        return _mapper.Map<RamDTO>(res);
    }

    public async Task Delete(int id)
    {
        await _repo.Delete(id);
        await _saveData.Save();
    }

    public async Task<List<RamDTO>> GetAll()
    {
        var res = await _repo.GetRams();
        return _mapper.Map<List<RamDTO>>(res);
    }

    public async Task<RamDTO> GetById(int id)
    {
        var res = await _repo.GetById(id);
        return _mapper.Map<RamDTO>(res);
    }

    public async Task Update(RamDTO updateRam)
    {
        try
        {
            var res = _mapper.Map<RamMemories>(updateRam);
            await _repo.Update(res);
            await _saveData.Save();
        }
        catch
        {
            throw;
        }
    }

    public async Task<List<RamSpeedDTO>> GetAllSpeed()
    {
        var res = await _repo.GetRamSpeeds();
        return _mapper.Map<List<RamSpeedDTO>>(res);
    }

    public async Task<RamSpeedDTO> GetSpeedById(int id)
    {
        var res = await _repo.GetSpeedById(id);
        return _mapper.Map<RamSpeedDTO>(res);
    }

    public async Task<RamSpeedDTO> AddSpeed(AddRamSpeedDTO post)
    {
        var res = _mapper.Map<RamSpeed>(post);
        await _repo.AddSpeed(res);
        await _saveData.Save();
        return _mapper.Map<RamSpeedDTO>(res);
    }

    public async Task UpdateSpeed(RamSpeedDTO ram)
    {
        try
        {
            var res = _mapper.Map<RamSpeed>(ram);
            await _repo.UpdateSpeed(res);
            await _saveData.Save();
        }
        catch
        {
            throw;
        }
    }

    public async Task DeleteSpeed(int id)
    {
        await _repo.DeleteSpeed(id);
        await _saveData.Save();
    }
}
