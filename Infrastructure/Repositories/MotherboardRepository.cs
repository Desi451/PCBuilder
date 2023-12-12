using Domain.Entities.Components.Motherboard;
using Domain.Interfaces.Repository.Components;
using Infrastructure.Common;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

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

    public async Task DeleteMemoryForMotherBoard(int id)
    {
        var res = await GetMemories(id);
        //foreach(var item in res)
        //{
        //    if (item != null)
        //    {
        //        item.IsDeleted = true;
        //    }
        //} tutaj dac usuwanie?
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
        var res = await _context.Motherboards.ToListAsync();
        return res;
    }

    public async Task Update(Motherboard mobo, List<int> Rams)
    {
        var res = await GetById(mobo.Id);

        Helper.CopyProperties(mobo, res);
        // Pobieranie starej listy pamięci z bazy danych
        var oldRams = await _context.MotherboardMemories
            .Where(x => x.MotherBoardId == mobo.Id)
            .Select(x => x.MemoryId)
            .ToListAsync();

        var newRamsNotInOldRams = Rams.Except(oldRams).ToList();
        foreach (var ram in newRamsNotInOldRams) 
        {
            MotheboardMemory item = new MotheboardMemory();
            item.MotherBoardId = mobo.Id;
            item.MemoryId = ram;
            await AddMemory(item);
        }

        var oldRamsNotInRams = oldRams.Except(Rams).ToList();

        var memoriesToRemove = await _context.MotherboardMemories
            .Where(x => x.MotherBoardId == mobo.Id && oldRamsNotInRams.Contains(x.MemoryId))
            .ToListAsync();

        _context.MotherboardMemories.RemoveRange(memoriesToRemove);
        
        // dodac sam obiekt jeszcze
    }


    public async Task UpdateMemory(List<MotheboardMemory> mobo, int id)
    {
        var res = await GetMemories(id);
        foreach (var i in res)
        {
            Helper.CopyProperties(mobo, res);
        }
    }
}
