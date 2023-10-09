using Domain.Entities;

namespace Domain.Interfaces.Repository;

public interface ISeriesRepository
{
    Task Add(Series series);
    Task Update(Series series);
    Task Delete(int id);

    //query
    Task<List<Series>> GetSeries();
    Task<Series> GetById(int id);
}
