using Domain.Entities.Components.Case;
using Domain.Entities.Components.RamMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repository.Components;

public interface IRamMemoryInterface
{
    Task Add(RamMemory ram);
    Task Update(RamMemory ram);
    Task Delete(int id);

    //query
    Task<List<RamMemory>> GetRams();
    Task<RamMemory> GetById(int id);

    //RamMemory
}
