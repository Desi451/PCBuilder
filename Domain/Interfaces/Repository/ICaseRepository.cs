using Domain.Entities.Components.Case;

namespace Domain.Interfaces.Repository;

public interface ICaseRepository
{
    Task Add(Case box);
    Task Update(Case box);
    Task Delete(int id);

    //query
    Task<List<Case>> GetBrands();
    Task<Case> GetById(int id);
}
