using Domain.Entities.Components.RamMemory;

namespace Domain.Interfaces.Repository.Components;

public interface IRamRepository
{
    Task Add(RamMemories ram);
    Task Update(RamMemories ram);
    Task Delete(int id);

    //query
    Task<List<RamMemories>> GetRams();
    Task<RamMemories> GetById(int id);

    //RamMemory
    Task AddSpeed(RamSpeed ram);
    Task UpdateSpeed(RamSpeed ram);
    Task DeleteSpeed(int id);

    //query
    Task<List<RamSpeed>> GetRamSpeeds();
    Task<RamSpeed> GetSpeedById(int id);
}
