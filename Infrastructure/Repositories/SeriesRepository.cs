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

    public async Task Add(Series series)
    {
        series.IsDeleted = false;
        series.CreatedBy = 1;
        await _context.AddAsync(series);
    }

    public async Task Delete(int id)
    {
        var res = await GetById(id);
        if (res != null)
        {
            res.IsDeleted = true;
        }
    }

    public async Task Update(Series series)
    {
        var oldSeries = await GetById(series.Id);
        oldSeries.Name = series.Name;
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

    public async Task<List<Series>> GetByBrandId(int id)
    {
        return await _context.Series.Where(x => x.BrandId == id).ToListAsync();
    }
    #endregion
}
