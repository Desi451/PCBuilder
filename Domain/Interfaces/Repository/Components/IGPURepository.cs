using Domain.Entities.Components.GPU;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repository.Components;

public interface IGPURepository
{
    Task Add(GPU gpu);
    Task Update(GPU gpu);
    Task Delete(int id);

    //query
    Task<List<GPU>> GetPSUs();
    Task<GPU> GetById(int id);
}
