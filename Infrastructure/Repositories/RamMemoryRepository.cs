using Application.Service.Common;
using Domain.Entities.Components.RamMemory;
using Domain.Interfaces.Repository.Components;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class RamMemoryRepository : IRamRepository
{
    private AppDbContext _context;

    public RamMemoryRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task Add(RamMemories ram)
    {
        await _context.AddAsync(ram);
    }

    public async Task AddSpeed(RamSpeed ram)
    {
        await _context.AddAsync(ram);
    }

    public async Task Delete(int id)
    {
        var res = await GetById(id);
        if (res != null)
        {
            res.IsDeleted = true;
        }
    }

    public async Task DeleteSpeed(int id)
    {
        var res = await GetSpeedById(id);
        if (res != null)
        {
            res.IsDeleted = true;
        }
    }

    public async Task<RamMemories> GetById(int id)
    {
        RamMemories? ram = await _context.RAMs.FirstOrDefaultAsync(x => x.Id == id);
        return ram;
    }

    public async Task<List<RamMemories>> GetRams()
    {
        return await _context.RAMs.ToListAsync();
    }

    public async Task<List<RamSpeed>> GetRamSpeeds()
    {
        return await _context.RamSpeeds.ToListAsync();
    }

    public async Task<RamSpeed> GetSpeedById(int id)
    {
        var res = await _context.RamSpeeds.FirstOrDefaultAsync(x => x.Id == id);
        return res;
    }

    public async Task Update(RamMemories ram)
    {
        var oldRam = await GetById(ram.Id) ?? throw new NotFoundException($"No RAM with ID = {ram.Id}");
        oldRam.Name = ram.Name;
        oldRam.Model = ram.Model;
        oldRam.Capacity = ram.Capacity;
        oldRam.NoELements = ram.NoELements;
        oldRam.Description = ram.Description;
        oldRam.Latency = ram.Latency;
        oldRam.MemorySpeedId = ram.MemorySpeedId;
        oldRam.SeriesId = ram.SeriesId;
    }

    public async Task UpdateSpeed(RamSpeed ram)
    {
        var oldSpeed = await GetSpeedById(ram.Id) ?? throw new NotFoundException($"No RAM speed with ID = {ram.Id}");
        oldSpeed.Standard = ram.Standard;
        oldSpeed.Freq = ram.Freq;
    }
}
