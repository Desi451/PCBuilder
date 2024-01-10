using Domain.Entities.Components.CPU;

namespace Domain.Interfaces.Repository.Components;

public interface ICPURepository
{
    Task Add(CPU Cpu);
    Task Update(CPU Cpu);
    Task Delete(int id);

    //query
    Task<List<CPU>> GetCPUs();
    Task<CPU> GetById(int id);

    //CPU socket
    Task AddSocket(SocketCPU socket);
    Task UpdateSocket(SocketCPU socket);
    Task DeleteSocket(int id);

    //query
    Task<List<SocketCPU>> GetSocketsByBrandId(int id);
    Task<List<SocketCPU>> GetSockets();
    Task<SocketCPU> GetSocketById(int id);
}