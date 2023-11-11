using Application.DTO.Components.CPU;
using Application.Interfaces.Components;
using AutoMapper;
using Domain.Entities.Components.CPU;
using Domain.Interfaces.Common;
using Domain.Interfaces.Repository.Components;

namespace Application.Service.Components;

public class CPUService : ICPUService
{

    private ICPURepository _repo;
    private readonly ISaveData _saveData;
    private readonly IMapper _mapper;

    public CPUService(ICPURepository repo, ISaveData saveData, IMapper mapper)
    {
        _repo = repo;
        _saveData = saveData;
        _mapper = mapper;
    }

    public async Task<CpuDTO> Add(AddCpuDTO post)
    {
        var res = _mapper.Map<CPU>(post);
        await _repo.Add(res);
        await _saveData.Save();
        return _mapper.Map<CpuDTO>(post);
    }

    public async Task Delete(int id)
    {
        await _repo.Delete(id);
        await _saveData.Save();
    }

    public async Task<List<CpuDTO>> GetAll()
    {
        var res = await _repo.GetCPUs();
        return _mapper.Map<List<CpuDTO>>(res);
    }

    public async Task<CpuDTO> GetById(int id)
    {
        var res = await _repo.GetById(id);
        return _mapper.Map<CpuDTO>(res);
    }

    public async Task Update(CpuDTO updateCpu)
    {
        var res = _mapper.Map<CPU>(updateCpu);
        await _repo.Update(res);
        await _saveData.Save();
    }

    public async Task<List<SocketCpuDTO>> GetAllSockets()
    {
        var res = await _repo.GetSockets();
        return _mapper.Map<List<SocketCpuDTO>>(res);
    }

    public async Task<SocketCpuDTO> GetSocketById(int id)
    {
        var res = await _repo.GetSocketById(id);
        return _mapper.Map<SocketCpuDTO>(res);
    }

    public  async Task<SocketCpuDTO> AddSocket(AddSocketCpuDTO post)
    {
        var res = _mapper.Map<SocketCPU>(post);
        await _repo.AddSocket(res);
        await _saveData.Save();
        return _mapper.Map<SocketCpuDTO>(post);
    }

    public async Task UpdateSocket(SocketCpuDTO updateCpu)
    {
        var res = _mapper.Map<SocketCPU>(updateCpu);
        await _repo.UpdateSocket(res);
        await _saveData.Save();
    }

    public async Task DeleteSocket(int id)
    {
        await _repo.DeleteSocket(id);
        await _saveData.Save();
    }
}
