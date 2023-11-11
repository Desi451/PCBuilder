using Domain.Entities.Components;

namespace Domain.Interfaces.Repository.Components;

public interface IPowerSupplyRepository
{
    Task Add(PowerSupply psu);
    Task Update(PowerSupply psu);
    Task Delete(int id);

    //query
    Task<List<PowerSupply>> GetPSUs();
    Task<PowerSupply> GetById(int id);
}
