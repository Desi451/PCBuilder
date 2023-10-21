using Domain.Entities.Components.Case;
using Domain.Interfaces.Repository;

namespace Infrastructure.Repositories;

public class CaseRepository : ICaseRepository
{
    public Task Add(Case box)
    {
        throw new NotImplementedException();
    }

    public Task Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Case>> GetBrands()
    {
        throw new NotImplementedException();
    }

    public Task<Case> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task Update(Case box)
    {
        throw new NotImplementedException();
    }
}
