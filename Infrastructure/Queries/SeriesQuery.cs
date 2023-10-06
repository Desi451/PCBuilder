using Domain.Entities;
using Domain.Interfaces.Query;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Queries;

public class SeriesQuery : ISeriesQuery
{
    private readonly AppDbContext _context;

    public SeriesQuery(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Series> GetById(int id)
    {
        return await _context.Series.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<Series>> GetSeries()
    {
        return await _context.Series.ToListAsync();
    }
}
