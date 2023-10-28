using Domain.Entities.Components.Case;

namespace Domain.Interfaces.Repository.Components;

public interface ICaseRepository
{
    Task Add(Case box);
    Task Update(Case box);
    Task Delete(int id);

    //query
    Task<List<Case>> GetCases();
    Task<Case> GetById(int id);
}
