using Domain.Entities.Components.RamMemory;
using Domain.Interfaces.Repository.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories;

public class RamMemoryRepository : IRamMemoryInterface
{
    public Task Add(RamMemory ram)
    {
        throw new NotImplementedException();
    }

    public Task Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task<RamMemory> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<RamMemory>> GetRams()
    {
        throw new NotImplementedException();
    }

    public Task Update(RamMemory ram)
    {
        throw new NotImplementedException();
    }
}
