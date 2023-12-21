using Domain.Entities.Components.Drives;

namespace Domain.Interfaces.Repository.Components;

public interface IHddRepository
{
    Task Add(Hdd gpu);
    Task Update(Hdd gpu);
    Task Delete(int id);

    //query
    Task<List<Hdd>> GetHdds();
    Task<Hdd> GetById(int id);
}
