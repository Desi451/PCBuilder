using Application.DTO.Components.Motherboard;
using Application.Interfaces.Components;
using AutoMapper;
using Domain.Entities.Components.Motherboard;
using Domain.Interfaces.Common;
using Domain.Interfaces.Repository.Components;

namespace Application.Service.Components;

public class MotherboardService : IMotherBoardService
{
    private IMotherBoardRepository _repo;
    private readonly ISaveData _saveData;
    private readonly IMapper _mapper;

    public MotherboardService(IMotherBoardRepository repo, ISaveData saveData, IMapper mapper)
    {
        _repo = repo;
        _saveData = saveData;
        _mapper = mapper;
    }

    public async Task Add(AddMotherboardDTO mobo)
    {
        var res = _mapper.Map<Motherboard>(mobo);
        await _repo.Add(res);
        await _saveData.Save();
        foreach(var item in mobo.Memory)
        {
            var i = _mapper.Map<MotheboardMemory>(item);
            i.MotherBoardId = res.Id;
            await _repo.AddMemory(i);
        }
        await _saveData.Save();
    }

    public async Task AddMemory(AddMotherboardMemoryDTO mobo)
    {
        var i = _mapper.Map<MotheboardMemory>(mobo);
        await _repo.AddMemory(i);
        await _saveData.Save();
    }

    public async Task Delete(int id)
    {
        await _repo.Delete(id);
        await _repo.DeleteMemory(id);
        await _saveData.Save();
    }

    public async Task DeleteMemory(int id)
    {
        await _repo.DeleteMemory(id);
        await _saveData.Save();
    }

    public async Task<MotherboardDTO> GetById(int id)
    {
        var res = await _repo.GetById(id);
        return _mapper.Map<MotherboardDTO>(res);
    }

    public async Task<List<MotherboardMemoryDTO>> GetMemories(int id)
    {
        var res = await _repo.GetMemories(id);
        List<MotherboardMemoryDTO> memories = new List<MotherboardMemoryDTO>();
        foreach (var mem in res)
        {
            var item = _mapper.Map<MotherboardMemoryDTO>(mem);
            memories.Add(item);
        }
        return memories;
    }

    public async Task<MotherboardMemoryDTO> GetMemoryById(int id)
    {
        var res = await _repo.GetMemoryById(id);
        return _mapper.Map<MotherboardMemoryDTO>(res);
    }

    public async Task<List<MotherboardDTO>> GetMotherboards()
    {
        var res = await _repo.GetMotherboards();
        return _mapper.Map<List<MotherboardDTO>>(res);
    }

    public async Task Update(MotherboardDTO mobo)
    {
        var res = _mapper.Map<Motherboard>(mobo);
        await _repo.Update(res);
        await _saveData.Save();
    }

    public async Task UpdateMemory(List<MotherboardMemoryDTO> mobo, int id)
    {
        var res = _mapper.Map<List<MotheboardMemory>>(mobo);
        await _repo.UpdateMemory(res, id);
        await _saveData.Save();
    }
}
