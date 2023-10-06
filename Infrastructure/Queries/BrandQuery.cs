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

public class BrandQuery : IBrandQuery
{
    private readonly AppDbContext _context;

    public BrandQuery(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Brand>> GetBrands()
    {
        return await _context.Brands.ToListAsync();
    }

    public async Task<Brand> GetById(int id)
    {
        try
        {
            var res = await _context.Brands.FirstOrDefaultAsync(x => x.Id == id);
            return res;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}
