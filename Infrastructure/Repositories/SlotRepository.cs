using Domain.Entities.Components.Case;
using Domain.Entities.Slots;
using Domain.Interfaces.Repository;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories;

public class SlotRepository : ISlotRepository
{
    private readonly AppDbContext _context;

    public SlotRepository(AppDbContext appDbContext)
    {
        _context = appDbContext;
    }

    public async Task Add(SlotInterface slot)
    {
        slot.IsDeleted = false;
        slot.Created = DateTime.Now;
        await _context.AddAsync(slot);
    }

    public async Task Delete(int id)
    {
        var res = await GetById(id);
        if (res != null)
        {
            res.IsDeleted = true;
        }
    }

    public async Task<List<SlotInterface>> Get()
    {
        return await _context.SlotInterfaces.ToListAsync();
    }

    public async Task<SlotInterface> GetById(int id)
    {
        try
        {
            return await _context.SlotInterfaces.FirstOrDefaultAsync(x => x.Id == id);
        }
        catch
        {
            throw;
        }
    }

    public async Task Update(SlotInterface slot)
    {
        var oldSlot = await GetById(slot.Id);
        oldSlot.Name = slot.Name;
        oldSlot.LastModified = DateTime.Now;
    }
}
