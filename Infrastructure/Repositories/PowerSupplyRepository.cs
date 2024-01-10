using Domain.Entities.Components;
using Domain.Interfaces.Repository.Components;
using Infrastructure.Common;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class PowerSupplyRepository : IPowerSupplyRepository
{
    private readonly AppDbContext _context;
    public PowerSupplyRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task Add(PowerSupply psu)
    {
        psu.IsDeleted = false;
        psu.Created = DateTime.Now;
        await _context.AddAsync(psu);
    }

    public async Task Delete(int id)
    {
        var res = await GetById(id);
        if (res != null)
        {
            res.IsDeleted = true;
        }
    }

    public async Task<List<PowerSupply>> GetPSUs()
    {
        return await _context.PSUs.ToListAsync();
    }

    public async Task<PowerSupply> GetById(int id)
    {
        return await _context.PSUs.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task Update(PowerSupply psu)
    {
        var oldPsu = await _context.PSUs.FirstOrDefaultAsync(r => r.Id == psu.Id);
        Helper.CopyProperties(psu, oldPsu);
        oldPsu.LastModified = DateTime.Now;
    }
}
