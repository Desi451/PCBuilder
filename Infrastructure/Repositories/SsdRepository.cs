using Application.Service.Common;
using Domain.Entities.Components.Drives;
using Domain.Interfaces.Repository.Components;
using Infrastructure.Common;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class SsdRepository : ISsdRepository
{
    private AppDbContext _context;

    public SsdRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task Add(Ssd ssd)
    {
        ssd.IsDeleted = false;
        ssd.CreatedBy = 1;
        await _context.AddAsync(ssd);
    }

    public async Task Delete(int id)
    {
        var res = await GetById(id);
        res.IsDeleted = true;
    }

    public async Task<Ssd> GetById(int id)
    {
        var res = await _context.Ssds.
            FirstOrDefaultAsync(c => c.Id == id);
        return res == null ?
            throw new AppException("No case with this id") : res;
    }

    public async Task<List<Ssd>> GetSsds()
    {
        return await _context.Ssds.ToListAsync();
    }

    public async Task Update(Ssd ssd)
    {
        Ssd oldSsd = await GetById(ssd.Id);
        Helper.CopyProperties(ssd, oldSsd);
    }
}
