using Application.Service.Common;
using Domain.Entities.Slots;
using Domain.Interfaces.Repository;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

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
        return await _context.SlotInterfaces.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task Update(SlotInterface slot)
    {
        var oldSlot = await GetById(slot.Id) ?? throw new NotFoundException($"No slot with ID = {slot.Id}");
        oldSlot.Name = slot.Name;
    }
}
