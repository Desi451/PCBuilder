using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Query;

public interface ISeriesQuery
{
    public Task<List<Series>> GetSeries();
    public Task<Series> GetById(int id);
}
