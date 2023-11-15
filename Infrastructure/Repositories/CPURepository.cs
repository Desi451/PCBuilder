using Domain.Entities.Components.CPU;
using Domain.Interfaces.Repository.Components;
using Infrastructure.Common;
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
        Cpu.IsDeleted = false;
        Cpu.CreatedBy = 1;
        await _context.AddAsync(Cpu);
    }

    public async Task AddSocket(SocketCPU socket)
    {
        socket.IsDeleted = false;
        socket.CreatedBy = 1;
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
        CPU? Cpu = await _context.CPUs.FirstOrDefaultAsync(x => x.Id == id);
        return Cpu;
    }

    public async Task<List<CPU>> GetCPUs()
    {
        return await _context.CPUs.ToListAsync();
    }

    public async Task<SocketCPU> GetSocketById(int id)
    {
        return await _context.SocketCPUs.FirstOrDefaultAsync(_ => _.Id == id);
    }

    public async Task<List<SocketCPU>> GetSockets()
    {
        return await _context.SocketCPUs.ToListAsync();
    }

    public async Task Update(CPU Cpu)
    {
        var oldCpu = await _context.CPUs.FirstOrDefaultAsync(r => r.Id == Cpu.Id);
        Helper.CopyProperties(Cpu, oldCpu);
    }

    public async Task UpdateSocket(SocketCPU socket)
    {
        var oldCpu = await _context.SocketCPUs.FirstOrDefaultAsync(r => r.Id == socket.Id);
        Helper.CopyProperties(socket, oldCpu);
    }
}
