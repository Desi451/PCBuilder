using Domain.Entities;
using Domain.Interfaces.Repository;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class SeriesRepository : ISeriesRepository
{
    private readonly AppDbContext _context;

    public SeriesRepository(AppDbContext context)
    {
        _context = context;
    }

    public Task Add(Series series)
    {
        throw new NotImplementedException();
    }

    public Task Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task Update(Series series)
    {
        throw new NotImplementedException();
    }

    #region query
    public async Task<Series> GetById(int id)
    {
        return await _context.Series.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<Series>> GetSeries()
    {
        return await _context.Series.ToListAsync();
    }
    #endregion
}
