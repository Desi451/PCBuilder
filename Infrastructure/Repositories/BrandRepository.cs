using Domain.Entities;
using Domain.Interfaces.Repository;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class BrandRepository : IBrandRepository
{
    private AppDbContext _context;

    public BrandRepository(AppDbContext appDbContext)
    {
        _context = appDbContext;
    }

    public async Task Add(Brand brand)
    {
        brand.IsDeleted = false;
        brand.Created = DateTime.Now;
        await _context.AddAsync(brand);
    }

    public async Task Delete(int id)
    {
        var res = await GetById(id);
        if (res != null)
        {
            res.IsDeleted = true;
        }
    }

    public async  Task Update(Brand brand)
    {
        var oldSeries = await GetById(brand.Id);
        oldSeries.Name = brand.Name;
        oldSeries.LastModified = DateTime.Now;
    }

    #region query
    public async Task<List<Brand>> GetBrands()
    {
        try
        {
            return await _context.Brands
            .Where(x => x.IsDeleted == false)
            .ToListAsync();
        }
        catch
        {
            throw;
        }
    }

    public async Task<Brand> GetById(int id)
    {
        try
        {
            return await _context.Brands.FirstOrDefaultAsync(x => x.Id == id);
        }
        catch
        {
            throw;
        }
    }
    #endregion
}
