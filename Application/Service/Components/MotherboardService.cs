using Application.DTO.Components.Motherboard;
using Application.DTO.Components.RAM;
using Application.Interfaces.Components;
using AutoMapper;
using Domain.Entities.Components.Motherboard;
using Domain.Entities.Components.RamMemory;
using Domain.Interfaces.Common;
using Domain.Interfaces.Repository.Components;

namespace Application.Service.Components;

public class MotherboardService : IMotherBoardService
{
    private IMotherBoardRepository _repo;
    private IRamRepository _ramRepository;
    private readonly ISaveData _saveData;
    private readonly IMapper _mapper;

    public MotherboardService(IMotherBoardRepository repo, ISaveData saveData, IMapper mapper,
        IRamRepository ram)
    {
        _ramRepository = ram;
        _repo = repo;
        _saveData = saveData;
        _mapper = mapper;
    }

    public async Task Add(AddMotherboardDTO mobo)
    {
        var res = _mapper.Map<Motherboard>(mobo);
        await _repo.Add(res);
        await _saveData.Save();
        foreach(var item in mobo.Memories)
        {
            MotheboardMemory mem = new MotheboardMemory();
            var ram = await _ramRepository.GetSpeedById(item.Id);
            mem.Memory = ram;
            mem.MemoryId = ram.Id;
            mem.Motherboard = res;
            mem.MotherBoardId = res.Id;
            await _repo.AddMemory(mem);
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
        var mobo = _mapper.Map<MotherboardDTO>(res);
        mobo.Memories = await GetMemories(id);
        return mobo;
    }

    public async Task<List<RamSpeedDTO>> GetMemories(int id)
    {
        var res = await _repo.GetMemories(id);
        List<RamSpeedDTO> memories = new List<RamSpeedDTO>();
        foreach (var mem in res)
        {
            var item = await _ramRepository.GetSpeedById(mem.MemoryId);
            var speed = _mapper.Map<RamSpeedDTO>(item);
            memories.Add(speed);
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
        foreach(var i in res)
        {
            var mobo = _mapper.Map<MotherboardDTO>(i);
            mobo.Memories = await GetMemories(i.Id);
        }
        return _mapper.Map<List<MotherboardDTO>>(res);
    }

    public async Task Update(UpdateMotherboardDTO mobo)
    {
        var res = _mapper.Map<Motherboard>(mobo);
        await _repo.Update(res, _mapper.Map<List<RamSpeed>>(mobo.Memories));
        await _saveData.Save();
    }

    public async Task UpdateMemory(List<MotherboardMemoryDTO> mobo, int id)
    {
        var res = _mapper.Map<List<MotheboardMemory>>(mobo);
        await _repo.UpdateMemory(res, id);
        await _saveData.Save();
    }
}
