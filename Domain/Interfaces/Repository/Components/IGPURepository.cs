using Domain.Entities.Components.GPU;

namespace Domain.Interfaces.Repository.Components;

public interface IGPURepository
{
    Task Add(GPU gpu);
    Task Update(GPU gpu);
    Task Delete(int id);

    //query
    Task<List<GPU>> GetGpus();
    Task<GPU> GetById(int id);
}
