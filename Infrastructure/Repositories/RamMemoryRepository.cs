using Domain.Entities;
using Domain.Entities.Components.RamMemory;
using Domain.Interfaces.Repository.Components;
using Infrastructure.Common;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories;

public class RamMemoryRepository : IRamRepository
{
    private AppDbContext _context;

    public RamMemoryRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task Add(RamMemory ram)
    {
        ram.IsDeleted = false;
        ram.CreatedBy = 1;
        await _context.AddAsync(ram);
    }

    public async Task AddSpeed(RamSpeed ram)
    {
        ram.IsDeleted = false;
        ram.CreatedBy = 1;
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

    public async Task<RamMemory> GetById(int id)
    {
        RamMemory? ram = await _context.RAMs.FirstOrDefaultAsync(x => x.Id == id);
        return ram;
    }

    public async Task<List<RamMemory>> GetRams()
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

    public async Task Update(RamMemory ram)
    {
        var oldRam = await _context.RAMs.Where(r => r.Id == ram.Id).FirstOrDefaultAsync();
        Helper.CopyProperties(ram, oldRam);
    }

    public async  Task UpdateSpeed(RamSpeed ram)
    {
        var oldRam = await _context.RamSpeeds.Where(r => r.Id == ram.Id).FirstOrDefaultAsync();
        Helper.CopyProperties(ram, oldRam);
    }
}
