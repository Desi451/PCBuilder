using Application.Service.Common;
using Domain.Entities.Components;
using Domain.Interfaces.Repository.Components;
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
        var oldPsu = await GetById(psu.Id) ?? throw new NotFoundException($"No power supply with ID = {psu.Id}");
        oldPsu.Name = psu.Name;
        oldPsu.Model = psu.Model;
        oldPsu.standard = psu.standard;
        oldPsu.Power = psu.Power;
        oldPsu.Fans = psu.Fans;
        oldPsu.HasPFC = psu.HasPFC;
        oldPsu.MainConnPins = psu.MainConnPins;
        oldPsu.PCIExpressConn = psu.PCIExpressConn;
        oldPsu.HasSLI = psu.HasSLI;
        oldPsu.HasCrossFire = psu.HasCrossFire;
        oldPsu.Voltage = psu.Voltage;
        oldPsu.Freq = psu.Freq;
        oldPsu.Connectors = psu.Connectors;
        oldPsu.Description = psu.Description;
        oldPsu.Dimensions = psu.Dimensions;
        oldPsu.SeriesId = psu.SeriesId;
    }
}
