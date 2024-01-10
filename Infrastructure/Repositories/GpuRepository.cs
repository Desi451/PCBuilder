using Application.Service.Common;
using Domain.Entities.Components.GPU;
using Domain.Interfaces.Repository.Components;
using Infrastructure.Common;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class GpuRepository : IGPURepository
{
    private AppDbContext _context;

    public GpuRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task Add(GPU gpu)
    {
        gpu.IsDeleted = false;
        gpu.Created = DateTime.Now;
        await _context.AddAsync(gpu);
    }

    public async Task Delete(int id)
    {
        var res = await GetById(id);
        res.IsDeleted = true;
    }

    public async Task<GPU> GetById(int id)
    {
        var res = await _context.GPUs.
            FirstOrDefaultAsync(c => c.Id == id);
        return res == null ?
            throw new AppException("No case with this id") : res;
    }

    public async Task<List<GPU>> GetGpus()
    {
        return await _context.GPUs.ToListAsync();
    }

    public async Task Update(GPU gpu)
    {
        GPU oldBox = await GetById(gpu.Id);
        Helper.CopyProperties(gpu, oldBox);
        oldBox.LastModified = DateTime.Now;
    }
}
