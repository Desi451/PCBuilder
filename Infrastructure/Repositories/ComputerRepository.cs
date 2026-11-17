using Application.Service.Common;
using Domain.Entities;
using Domain.Entities.Components;
using Domain.Entities.Components.Case;
using Domain.Entities.Components.CPU;
using Domain.Entities.Components.Drives;
using Domain.Entities.Components.Motherboard;
using Domain.Entities.Components.RamMemory;
using Domain.Entities.Computer;
using Domain.Interfaces.Repository;
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
        await _context.Computers.AddAsync(computer);
        await SyncHdds(computer, Hdds.Select(hdd => hdd.Id).ToList());
        await SyncSsds(computer, Ssds.Select(ssd => ssd.Id).ToList());
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
        return await QueryComputersWithComponents()
            .Include(c => c.Cpu)
            .Include(c => c.RamMemory)
            .ToListAsync();
    }

    public async Task<List<Computer>> GetComputersViewByUser(int id)
    {
        return await QueryComputersWithComponents()
            .Include(c => c.Cpu)
            .Include(c => c.RamMemory)
            .Where(x => x.UserId == id)
            .ToListAsync();
    }

    public async Task<Computer> GetFullDataById(int id)
    {
        var computer = await QueryComputersWithComponents()
            .Include(c => c.Case)
            .Include(c => c.Cpu)
                .ThenInclude(cpu => cpu.Series)
                .ThenInclude(series => series.Brand)
            .Include(c => c.Mobo)
            .Include(c => c.RamMemory)
            .Include(c => c.Psu)
            .Include(c => c.Gpu)
            .FirstOrDefaultAsync(x => x.Id == id);

        if (computer != null)
        {
            computer.Drives = await _context.ComputerHdds
                .IgnoreQueryFilters()
                .AsNoTracking()
                .Where(link => link.ComputerId == id)
                .Select(link => link.Hdd!)
                .ToListAsync();

            computer.Ssds = await _context.ComputerSsds
                .IgnoreQueryFilters()
                .AsNoTracking()
                .Where(link => link.ComputerId == id)
                .Select(link => link.Ssd!)
                .ToListAsync();
        }

        return computer;
    }

    public async Task<List<Computer>> GetComputers()
    {
        return await _context.Computers.AsNoTracking().ToListAsync();
    }

    public async Task Update(Computer computer, List<Hdd> Hdds, List<Ssd> Ssds)
    {
        var res = await GetById(computer.Id) ?? throw new NotFoundException($"No computer with ID = {computer.Id}");

        res.Name = computer.Name;
        res.CaseId = computer.CaseId;
        res.CpuId = computer.CpuId;
        res.MotherboardId = computer.MotherboardId;
        res.RamMemoryId = computer.RamMemoryId;
        res.PsuId = computer.PsuId;
        res.GpuId = computer.GpuId;

        await SyncHdds(res, Hdds.Select(hdd => hdd.Id).ToList());
        await SyncSsds(res, Ssds.Select(ssd => ssd.Id).ToList());
    }

    public async Task AddHdd(ComputerHdds hdd)
    {
        await _context.AddAsync(hdd);
    }

    public async Task AddSsd(ComputerSsds ssd)
    {
        await _context.AddAsync(ssd);
    }

    public async Task DeleteHdd(int id)
    {
        var link = await _context.ComputerHdds.FirstOrDefaultAsync(x => x.Id == id);
        if (link != null)
        {
            _context.ComputerHdds.Remove(link);
        }
    }

    public async Task DeleteSsd(int id)
    {
        var link = await _context.ComputerSsds.FirstOrDefaultAsync(x => x.Id == id);
        if (link != null)
        {
            _context.ComputerSsds.Remove(link);
        }
    }

    /// <summary>
    /// computer configuration
    /// </summary>

    public async Task<List<Brand>> GetBrandsForCPUSocketsAsync()
    {
        return await _context.Brands
            .AsNoTracking()
            .Where(b => _context.CPUs.Any(cpu => cpu.Series.BrandId == b.Id))
            .ToListAsync();
    }

    public async Task<List<CPU>> GetCPUsByBrandIdAsync(int brandId)
    {
        return await _context.CPUs
            .AsNoTracking()
            .Where(cpu => cpu.Series.BrandId == brandId)
            .ToListAsync();
    }

    public async Task<List<Motherboard>> GetMotherBoardsBySocket(int socketId)
    {
        return await _context.Motherboards
            .AsNoTracking()
            .Where(x => x.SocketCpuId == socketId)
            .ToListAsync();
    }

    public async Task<List<RamMemories>> GetRamsByMotherboard(int motherboardId)
    {
        return await _context.RAMs
            .AsNoTracking()
            .Where(ram => _context.MotherboardMemories
                .Any(link => link.MotherBoardId == motherboardId && link.MemoryId == ram.MemorySpeedId))
            .ToListAsync();
    }

    public async Task<List<PowerSupply>> GetPsusByWattage(int watt)
    {
        return await _context.PSUs.AsNoTracking().Where(x => x.Power >= watt).ToListAsync();
    }

    public async Task<List<Case>> GetCasesBySize(int caseSizeId, double gpuLength)
    {
        return await _context.Cases
            .AsNoTracking()
            .Where(x => (int)x.CaseSize <= caseSizeId && (gpuLength + 2) * 10 < x.Width)
            .ToListAsync();
    }

    // A computer keeps showing components that were soft-deleted after it was built,
    // so component filters are ignored here and only the computer's own flag is applied.
    private IQueryable<Computer> QueryComputersWithComponents()
    {
        return _context.Computers
            .IgnoreQueryFilters()
            .AsNoTracking()
            .Where(c => !c.IsDeleted);
    }

    private async Task SyncHdds(Computer computer, List<int> hddIds)
    {
        List<ComputerHdds> links = computer.Id == 0
            ? []
            : await _context.ComputerHdds.Where(x => x.ComputerId == computer.Id).ToListAsync();

        var linksToRemove = links.Where(x => !hddIds.Contains(x.HddId)).ToList();
        _context.ComputerHdds.RemoveRange(linksToRemove);

        var newHddIds = hddIds.Except(links.Select(x => x.HddId)).ToList();
        foreach (var hddId in newHddIds)
        {
            await AddHdd(new ComputerHdds
            {
                Computer = computer,
                HddId = hddId
            });
        }
    }

    private async Task SyncSsds(Computer computer, List<int> ssdIds)
    {
        List<ComputerSsds> links = computer.Id == 0
            ? []
            : await _context.ComputerSsds.Where(x => x.ComputerId == computer.Id).ToListAsync();

        var linksToRemove = links.Where(x => !ssdIds.Contains(x.SsdId)).ToList();
        _context.ComputerSsds.RemoveRange(linksToRemove);

        var newSsdIds = ssdIds.Except(links.Select(x => x.SsdId)).ToList();
        foreach (var ssdId in newSsdIds)
        {
            await AddSsd(new ComputerSsds
            {
                Computer = computer,
                SsdId = ssdId
            });
        }
    }
}
