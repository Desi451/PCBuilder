using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repository;

public interface ISeriesRepository
{
    Task Add(Series series);
    Task Update(Series series);
    Task Delete(int id);
}
