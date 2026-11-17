using Application.Service.Common;
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
        var oldBrand = await GetById(brand.Id) ?? throw new NotFoundException($"No brand with ID = {brand.Id}");
        oldBrand.Name = brand.Name;
    }

    #region query
    public async Task<List<Brand>> GetBrands()
    {
        return await _context.Brands.AsNoTracking().ToListAsync();
    }

    public async Task<Brand> GetById(int id)
    {
        return await _context.Brands.FirstOrDefaultAsync(x => x.Id == id);
    }
    #endregion
}
