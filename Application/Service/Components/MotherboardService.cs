using Application.DTO.Components.Motherboard;
using Application.Interfaces.Components;
using AutoMapper;
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

    public Task Add(AddMotherboardDTO mobo)
    {
        throw new NotImplementedException();
    }

    public Task AddMemory(AddMotherboardMemoryDTO mobo)
    {
        throw new NotImplementedException();
    }

    public Task Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task DeleteMemory(int id)
    {
        throw new NotImplementedException();
    }

    public Task<MotherboardDTO> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<MotherboardMemoryDTO>> GetMemories()
    {
        throw new NotImplementedException();
    }

    public Task<List<MotherboardMemoryDTO>> GetMemoryById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<MotherboardDTO>> GetMotherboards()
    {
        throw new NotImplementedException();
    }

    public Task Update(MotherboardDTO mobo)
    {
        throw new NotImplementedException();
    }

    public Task UpdateMemory(List<MotherboardMemoryDTO> mobo, int id)
    {
        throw new NotImplementedException();
    }
}
