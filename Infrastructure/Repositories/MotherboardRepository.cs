using Application.Service.Common;
using Domain.Entities.Components.Motherboard;
using Domain.Entities.Components.RamMemory;
using Domain.Interfaces.Repository.Components;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class MotherboardRepository : IMotherBoardRepository
{
    private AppDbContext _context;

    public MotherboardRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task Add(Motherboard mobo)
    {
        await _context.AddAsync(mobo);
    }

    public async Task AddMemory(MotheboardMemory mobo)
    {
        await _context.AddAsync(mobo);
    }

    public async Task Delete(int id)
    {
        var res = await GetById(id);
        if (res != null)
        {
            res.IsDeleted = true;
        }
    }

    public async Task DeleteMemory(int id)
    {
        var link = await GetMemoryById(id);
        if (link != null)
        {
            _context.MotherboardMemories.Remove(link);
        }
    }

    public async Task<Motherboard> GetById(int id)
    {
        var res = await _context.Motherboards.FirstOrDefaultAsync(x => x.Id == id);
        return res;
    }

    public async Task<MotheboardMemory> GetMemoryById(int id)
    {
        var res = await _context.MotherboardMemories.FirstOrDefaultAsync(x => x.Id == id);
        return res;
    }

    public async Task<List<MotheboardMemory>> GetMemories(int id)
    {
        var res = await _context.MotherboardMemories.Where(x => x.MotherBoardId == id)
            .ToListAsync();
        return res;
    }

    public async Task<List<Motherboard>> GetMotherboards()
    {
        return await _context.Motherboards.AsNoTracking().ToListAsync();
    }

    public async Task Update(Motherboard mobo, List<RamSpeed> Rams)
    {
        var res = await GetById(mobo.Id) ?? throw new NotFoundException($"No motherboard with ID = {mobo.Id}");

        res.Name = mobo.Name;
        res.Model = mobo.Model;
        res.SeriesId = mobo.SeriesId;
        res.SocketCpuId = mobo.SocketCpuId;
        res.Chipset = mobo.Chipset;
        res.MaxMemory = mobo.MaxMemory;
        res.SATASlots = mobo.SATASlots;
        res.M2Slots = mobo.M2Slots;
        res.RamSlots = mobo.RamSlots;
        res.CaseSize = mobo.CaseSize;
        res.Description = mobo.Description;

        await SyncMemories(res.Id, Rams.Select(ram => ram.Id).ToList());
    }

    public async Task UpdateMemory(List<MotheboardMemory> mobo, int id)
    {
        await SyncMemories(id, mobo.Select(memory => memory.MemoryId).ToList());
    }

    private async Task SyncMemories(int motherboardId, List<int> memoryIds)
    {
        var links = await _context.MotherboardMemories
            .Where(x => x.MotherBoardId == motherboardId)
            .ToListAsync();

        var linksToRemove = links.Where(x => !memoryIds.Contains(x.MemoryId)).ToList();
        _context.MotherboardMemories.RemoveRange(linksToRemove);

        var newMemoryIds = memoryIds.Except(links.Select(x => x.MemoryId)).ToList();
        foreach (var memoryId in newMemoryIds)
        {
            await AddMemory(new MotheboardMemory
            {
                MotherBoardId = motherboardId,
                MemoryId = memoryId
            });
        }
    }
}
