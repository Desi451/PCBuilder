using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Query;

public interface IBrandQuery
{
    public Task<List<Brand>> GetBrands();
    public Task<Brand> GetById(int id);
}
