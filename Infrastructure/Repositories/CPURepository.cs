using Domain.Entities.Components.CPU;
using Domain.Interfaces.Repository.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories;

public class CPURepository : ICPURepository
{
    public Task Add(CPU Cpu)
    {
        throw new NotImplementedException();
    }

    public Task Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task<CPU> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<CPU>> GetCases()
    {
        throw new NotImplementedException();
    }

    public Task Update(CPU Cpu)
    {
        throw new NotImplementedException();
    }
}
