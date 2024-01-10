using Application.DTO.Components.Motherboard;
using Application.DTO.Components.RAM;

namespace Application.Interfaces.Components;

public interface IMotherBoardService
{
    public Task Add(AddMotherboardDTO mobo);
    public Task Update(UpdateMotherboardDTO mobo);
    public Task Delete(int id);

    //query
    public Task<List<MotherboardDTO>> GetMotherboards();
    public Task<MotherboardDTO> GetById(int id);

    public Task AddMemory(AddMotherboardMemoryDTO mobo);
    public Task UpdateMemory(List<MotherboardMemoryDTO> mobo, int id);
    public Task DeleteMemory(int id);

    //query
    public Task<List<RamSpeedDTO>> GetMemories(int id);
    public Task<MotherboardMemoryDTO> GetMemoryById(int id);
}
