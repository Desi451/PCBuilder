using Domain.Entities.Components.Drives;

namespace Domain.Interfaces.Repository.Components;

public interface ISsdRepository
{
    Task Add(Ssd ssd);
    Task Update(Ssd ssd);
    Task Delete(int id);

    //query
    Task<List<Ssd>> GetSsds();
    Task<Ssd> GetById(int id);
}
