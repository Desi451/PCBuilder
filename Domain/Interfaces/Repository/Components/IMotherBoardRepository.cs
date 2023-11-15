using Domain.Entities.Components.Motherboard;

namespace Domain.Interfaces.Repository.Components;

public interface IMotherBoardRepository
{
    Task Add(Motherboard mobo);
    Task Update(Motherboard mobo);
    Task Delete(int id);

    //query
    Task<List<Motherboard>> GetMotherboards();
    Task<Motherboard> GetById(int id);

    Task AddMemory(MotheboardMemory mobo);
    Task UpdateMemory(List<MotheboardMemory> mobo, int id);
    Task DeleteMemory(int id);

    //query
    Task<List<MotheboardMemory>> GetMemories();
    Task<List<MotheboardMemory>> GetMemoryById(int id);
}
