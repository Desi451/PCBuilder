using Application.Service.Common;
using Domain.Entities.Components.CPU;
using Domain.Interfaces.Repository.Components;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class CPURepository : ICPURepository
{
    private AppDbContext _context;

    public CPURepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task Add(CPU Cpu)
    {
        await _context.AddAsync(Cpu);
    }

    public async Task AddSocket(SocketCPU socket)
    {
        await _context.AddAsync(socket);
    }

    public async Task Delete(int id)
    {
        var res = await GetById(id);
        if (res != null)
        {
            res.IsDeleted = true;
        }
    }

    public async Task DeleteSocket(int id)
    {
        var res = await GetSocketById(id);
        if (res != null)
        {
            res.IsDeleted = true;
        }
    }

    public async Task<CPU> GetById(int id)
    {
        CPU? Cpu = await _context.CPUs
            .FirstOrDefaultAsync(x => x.Id == id);
        return Cpu;
    }

    public async Task<List<CPU>> GetCPUs()
    {
        return await _context.CPUs.ToListAsync();
    }

    public async Task<SocketCPU> GetSocketById(int id)
    {
        return await _context.SocketCPUs
            .FirstOrDefaultAsync(_ => _.Id == id);
    }

    public async Task<List<SocketCPU>> GetSocketsByBrandId(int id)
    {
        return await _context.SocketCPUs
        .Where(x => x.BrandId == id)
        .ToListAsync();
    }

    public async Task<List<SocketCPU>> GetSockets()
    {
        return await _context.SocketCPUs.ToListAsync();
    }

    public async Task Update(CPU Cpu)
    {
        var oldCpu = await GetById(Cpu.Id) ?? throw new NotFoundException($"No CPU with ID = {Cpu.Id}");
        oldCpu.Name = Cpu.Name;
        oldCpu.Model = Cpu.Model;
        oldCpu.Cores = Cpu.Cores;
        oldCpu.Threads = Cpu.Threads;
        oldCpu.MinFreq = Cpu.MinFreq;
        oldCpu.MaxFreq = Cpu.MaxFreq;
        oldCpu.L2Cache = Cpu.L2Cache;
        oldCpu.L3Cache = Cpu.L3Cache;
        oldCpu.MaxRam = Cpu.MaxRam;
        oldCpu.IsAPU = Cpu.IsAPU;
        oldCpu.Technology = Cpu.Technology;
        oldCpu.TDP = Cpu.TDP;
        oldCpu.SeriesId = Cpu.SeriesId;
        oldCpu.SocketCpuId = Cpu.SocketCpuId;
        oldCpu.Description = Cpu.Description;
    }

    public async Task UpdateSocket(SocketCPU socket)
    {
        var oldSocket = await GetSocketById(socket.Id) ?? throw new NotFoundException($"No socket with ID = {socket.Id}");
        oldSocket.Name = socket.Name;
        oldSocket.BrandId = socket.BrandId;
    }
}
