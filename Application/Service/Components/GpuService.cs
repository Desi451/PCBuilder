using Application.DTO.Components.Case_Size;
using Application.DTO.Components.GPU;
using Application.Interfaces.Components;
using AutoMapper;
using Domain.Entities.Components.Case;
using Domain.Entities.Components.GPU;
using Domain.Interfaces.Common;
using Domain.Interfaces.Repository.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.Components;

public class GpuService : IGpuService
{

    private IGPURepository _repo;
    private readonly ISaveData _saveData;
    private readonly IMapper _mapper;

    public GpuService(IGPURepository repo, ISaveData saveData, IMapper mapper)
    {
        _repo = repo;
        _saveData = saveData;
        _mapper = mapper;
    }

    public async Task<GpuDTO> Add(AddGpuDTO post)
    {
        var res = _mapper.Map<GPU>(post);
        await _repo.Add(res);
        await _saveData.Save();
        return _mapper.Map<GpuDTO>(res);
    }

    public async Task Delete(int id)
    {
        await _repo.Delete(id);
        await _saveData.Save();
    }

    public async Task<List<GpuDTO>> GetAll()
    {
        var res = await _repo.GetGpus();
        return _mapper.Map<List<GpuDTO>>(res);
    }

    public async Task<GpuDTO> GetById(int id)
    {
        var res = await _repo.GetById(id);
        return _mapper.Map<GpuDTO>(res);
    }

    public async Task Update(GpuDTO updateCpu)
    {
        try
        {
            var res = _mapper.Map<GPU>(updateCpu);
            await _repo.Update(res);
            await _saveData.Save();
        }
        catch
        {
            throw;
        }
    }
}
