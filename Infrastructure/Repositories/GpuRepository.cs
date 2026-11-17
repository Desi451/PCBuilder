using Application.Service.Common;
using Domain.Entities.Components.GPU;
using Domain.Interfaces.Repository.Components;
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
        GPU oldGpu = await GetById(gpu.Id);
        oldGpu.SeriesId = gpu.SeriesId;
        oldGpu.ChipsetSeriesId = gpu.ChipsetSeriesId;
        oldGpu.Name = gpu.Name;
        oldGpu.CoreClock = gpu.CoreClock;
        oldGpu.MemorySize = gpu.MemorySize;
        oldGpu.MemoryInterface = gpu.MemoryInterface;
        oldGpu.MemoryType = gpu.MemoryType;
        oldGpu.DirectX = gpu.DirectX;
        oldGpu.OpenGL = gpu.OpenGL;
        oldGpu.TDP = gpu.TDP;
        oldGpu.RecommendedPsuPower = gpu.RecommendedPsuPower;
        oldGpu.Length = gpu.Length;
        oldGpu.Description = gpu.Description;
    }
}
