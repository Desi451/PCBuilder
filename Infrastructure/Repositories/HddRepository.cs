using Application.Service.Common;
using Domain.Entities.Components.Drives;
using Domain.Interfaces.Repository.Components;
using Infrastructure.Common;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class HddRepository : IHddRepository
{
    private AppDbContext _context;

    public HddRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task Add(Hdd gpu)
    {
        gpu.IsDeleted = false;
        gpu.CreatedBy = 1;
        await _context.AddAsync(gpu);
    }

    public async Task Delete(int id)
    {
        var res = await GetById(id);
        res.IsDeleted = true;
    }

    public async Task<Hdd> GetById(int id)
    {
        var res = await _context.Hdds.
           FirstOrDefaultAsync(c => c.Id == id);
        return res == null ?
            throw new AppException("No case with this id") : res;
    }

    public async Task<List<Hdd>> GetHdds()
    {
        return await _context.Hdds.ToListAsync();
    }

    public async Task Update(Hdd gpu)
    {
        Hdd oldHdd = await GetById(gpu.Id);
        Helper.CopyProperties(gpu, oldHdd);
    }
}
