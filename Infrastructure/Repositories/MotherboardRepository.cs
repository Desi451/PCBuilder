using Domain.Entities.Components.Motherboard;
using Domain.Interfaces.Repository.Components;
using Infrastructure.Common;
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
        mobo.IsDeleted = false;
        mobo.CreatedBy = 1;
        await _context.AddAsync(mobo);
    }

    public async Task AddMemory(MotheboardMemory mobo)
    {
        mobo.IsDeleted = false;
        mobo.CreatedBy = 1;
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
        var res = await GetById(id);
        if (res != null)
        {
            res.IsDeleted = true;
        }
    }

    public async Task<Motherboard> GetById(int id)
    {
        var res = await _context.Motherboards.FirstOrDefaultAsync(x => x.Id == id);
        return res;
    }

    public async Task<List<MotheboardMemory>> GetMemoryById(int id)
    {
        var res = await _context.MotherboardMemories.Where(x => x.MotherBoardId == id).ToListAsync();
        return res;
    }

    public async Task<List<MotheboardMemory>> GetMemories()
    {
        var res = await _context.MotherboardMemories.ToListAsync();
        return res;
    }

    public async Task<List<Motherboard>> GetMotherboards()
    {
        var res = await _context.Motherboards.ToListAsync();
        return res;
    }

    public async Task Update(Motherboard mobo)
    {
        var res = await GetById(mobo.Id);
        Helper.CopyProperties(mobo, res);
    }

    public async Task UpdateMemory(List<MotheboardMemory> mobo, int id)
    {
        var res = await GetMemoryById(id);
        foreach (var i in res)
        {
            Helper.CopyProperties(mobo, res);
        }
    }
}
