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

    public Task Add(Brand brand)
    {
        throw new NotImplementedException();
    }

    public Task Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task Update(Brand brand)
    {
        throw new NotImplementedException();
    }

    #region query
    public async Task<List<Brand>> GetBrands()
    {
        return await _context.Brands.ToListAsync();
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
