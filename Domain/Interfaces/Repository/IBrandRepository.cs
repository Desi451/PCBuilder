using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repository;

public interface IBrandRepository
{
    Task Add(Brand brand);
    Task Update(Brand brand);
    Task Delete(int id);
}
