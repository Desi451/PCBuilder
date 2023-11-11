using Domain.Entities.Components.RamMemory;

namespace Domain.Interfaces.Repository.Components;

public interface IRamRepository
{
    Task Add(RamMemory ram);
    Task Update(RamMemory ram);
    Task Delete(int id);

    //query
    Task<List<RamMemory>> GetRams();
    Task<RamMemory> GetById(int id);

    //RamMemory
    Task AddSpeed(RamSpeed ram);
    Task UpdateSpeed(RamSpeed ram);
    Task DeleteSpeed(int id);

    //query
    Task<List<RamSpeed>> GetRamSpeeds();
    Task<RamSpeed> GetSpeedById(int id);
}
