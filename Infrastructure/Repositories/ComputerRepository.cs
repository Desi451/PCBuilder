using Domain.Entities;
using Domain.Entities.Components;
using Domain.Entities.Components.Case;
using Domain.Entities.Components.CPU;
using Domain.Entities.Components.Drives;
using Domain.Entities.Components.Motherboard;
using Domain.Entities.Components.RamMemory;
using Domain.Entities.Computer;
using Domain.Interfaces.Repository;
using Infrastructure.Common;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ComputerRepository : IComputerRepository
{

    private AppDbContext _context;

    public ComputerRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task Add(Computer computer, List<Hdd> Hdds, List<Ssd> Ssds)
    {
        computer.IsDeleted = false;
        computer.Created = DateTime.Now;
        _context.Add(computer);

        await _context.SaveChangesAsync();

        foreach (var i in Hdds)
        {
            ComputerHdds item = new ComputerHdds
            {
                ComputerId = computer.Id,
                HddId = i.Id
            };

            await AddHdd(item);
        }

        foreach (var i in Ssds)
        {
            ComputerSsds item = new ComputerSsds
            {
                ComputerId = computer.Id,
                SsdId = i.Id
            };

            await AddSsd(item);
        }
    }

    public async Task Delete(int id)
    {
        var res = await GetById(id);
        if (res != null)
        {
            res.IsDeleted = true;
        }
    }

    public async Task<Computer> GetById(int id)
    {
        var res = await _context.Computers.FirstOrDefaultAsync(x => x.Id == id);
        return res;
    }

    public async Task<List<Computer>> GetComputersView()
    {
        var computer = await _context.Computers
        .Include(c => c.Case)
        .Include(c => c.Cpu)
        .Include(c => c.RamMemory)
        .ToListAsync();

        return computer;
    }

    public async Task<List<Computer>> GetComputersViewByUser(int id)
    {
        var computer = await _context.Computers
            .Include(c => c.Case)
            .Include(c => c.Cpu)
            .Include(c => c.RamMemory)
            .Where(x => x.UserId == id)
            .ToListAsync();

        return computer;
    }

    public async Task<Computer> GetFullDataById(int id)
    {
        var computer = await _context.Computers
        .Include(c => c.Case)
        .Include(c => c.Cpu)
        .Include(c => c.Mobo)
        .Include(c => c.RamMemory)
        .Include(c => c.Psu)
        .Include(c => c.Gpu)
        .FirstOrDefaultAsync(x => x.Id == id);

        if (computer != null)
        {
            computer.Drives = await _context.ComputerHdds
                .Where(ch => ch.ComputerId == id)
                .Join(
                    _context.Hdds,
                    computerHdd => computerHdd.HddId,
                    hdd => hdd.Id,
                    (computerHdd, hdd) => hdd)
                .ToListAsync();

            computer.Ssds = await _context.ComputerSsds
                .Where(cssd => cssd.ComputerId == id)
                .Join(
                    _context.Ssds,
                    computerSsd => computerSsd.SsdId,
                    ssd => ssd.Id,
                    (computerSsd, ssd) => ssd)
                .ToListAsync();
        }

        return computer;
    }

    public async Task<List<Computer>> GetComputers()
    {
        var res = await _context.Computers
            .Where(x => x.IsDeleted == false)
            .ToListAsync();
        return res;
    }

    public async Task Update(Computer computer, List<Hdd> Hdds, List<Ssd> Ssds)
    {
        var res = await GetById(computer.Id);

        Helper.CopyProperties(computer, res);
        res.LastModified = DateTime.Now;
        var oldHdds = await _context.ComputerHdds
            .Where(x => x.ComputerId == computer.Id)
            .Select(x => x.HddId)
            .ToListAsync();

        var newHddsInOld = Hdds.Select(hdd => hdd.Id).Except(oldHdds).ToList();

        foreach (var ramId in newHddsInOld)
        {
            ComputerHdds item = new ComputerHdds
            {
                ComputerId = computer.Id,
                HddId = ramId
            };

            await AddHdd(item);
        }

        var oldHddsNotInHdds = oldHdds.Except(Hdds.Select(hdd => hdd.Id)).ToList();

        var hddsToRemove = await _context.ComputerHdds
            .Where(x => x.ComputerId == computer.Id && oldHddsNotInHdds.Contains(x.HddId))
            .ToListAsync();

        _context.ComputerHdds.RemoveRange(hddsToRemove);

        var oldSsds = await _context.ComputerSsds
       .Where(x => x.ComputerId == computer.Id)
       .Select(x => x.SsdId)
       .ToListAsync();

        var  newSsdsNotInOld = Hdds.Select(ssd => ssd.Id).Except(oldSsds).ToList();

        foreach (var ssdId in newSsdsNotInOld)
        {
            ComputerSsds item = new ComputerSsds
            {
                ComputerId = computer.Id,
                SsdId = ssdId
            };

            await AddSsd(item);
        }

        var oldSsdsNotInSsd = oldSsds.Except(Ssds.Select(ssd => ssd.Id)).ToList();

        var memoriesToRemove = await _context.ComputerSsds
            .Where(x => x.ComputerId == computer.Id && oldSsdsNotInSsd.Contains(x.SsdId))
            .ToListAsync();

        _context.ComputerSsds.RemoveRange(memoriesToRemove);
        
        await _context.SaveChangesAsync();
    }

    public async Task AddHdd(ComputerHdds hdd)
    {
        await _context.AddAsync(hdd);
    }

    public async Task AddSsd(ComputerSsds hdd)
    {
        await _context.AddAsync(hdd);
    }

    public async Task DeleteHdd(int id)
    {
        await _context.ComputerHdds
            .Where(x => x.Id == id)
            .ExecuteDeleteAsync();
    }

    public async Task DeleteSsd(int id)
    {
        await _context.ComputerSsds
            .Where(x => x.Id == id)
            .ExecuteDeleteAsync();
    }

    /// <summary>
    /// computer configuration
    /// </summary>

    public async Task<List<Brand>> GetBrandsForCPUSocketsAsync()
    {
        var brandsForCPUSockets = await _context.Brands
            .Where(b => _context.CPUs.Any(cpu => cpu.Series.BrandId == b.Id))
            .ToListAsync();

        return brandsForCPUSockets;
    }

    public async Task<List<CPU>> GetCPUsByBrandIdAsync(int brandId)
    {
        var cpusForBrand = await _context.CPUs
            .Where(cpu => cpu.Series.BrandId == brandId)
            .ToListAsync();

        return cpusForBrand;
    }

    public async Task<List<Motherboard>> GetMotherBoardsBySocket(int socketId)
    {
        var res = await _context.Motherboards
            .Where(x => x.SocketCpuId == socketId)
            .ToListAsync();

        return res;
    }

    public async Task<List<RamMemories>> GetRamsByMotherboard(int motherboardId)
    {
        var res = await _context.MotherboardMemories
            .Where(x => x.MotherBoardId == motherboardId)
            .ToListAsync();

        List<RamMemories> ret = new List<RamMemories>();
        if (res != null)
        {
            foreach (var mem in res)
            {
                var mems = await _context.RAMs
                    .Where(x => x.MemorySpeed.Id == mem.MemoryId)
                    .ToListAsync();
                ret.AddRange(mems);
            }
        }

        return ret;

    }

    public async Task<List<PowerSupply>> GetPsusByWattage(int watt)
    {
        return await _context.PSUs.Where(x => x.Power >= watt).ToListAsync();
    }

    public async Task<List<Case>> GetCasesBySize(int caseSizeId, double gpuLength)
    {
        return await _context.Cases.Where(x => x.CaseSizeId <= caseSizeId && (gpuLength + 2)*10 < x.Width).ToListAsync();
    }


}
