using Domain.Entities.Components.Case;
using Domain.Entities.Components.CPU;
using Domain.Entities.Components.RamMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repository.Components;

public interface ICPURepository
{
    Task Add(CPU Cpu);
    Task Update(CPU Cpu);
    Task Delete(int id);

    //query
    Task<List<CPU>> GetCases();
    Task<CPU> GetById(int id);

    //CPU socket
}