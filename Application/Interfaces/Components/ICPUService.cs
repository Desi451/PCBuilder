using Application.DTO.BrandDTOs;
using Application.DTO.Components.CPU;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Components;

public interface ICPUService
{
    public Task<List<CpuDTO>> GetAll();
    public Task<CpuDTO> GetById(int id);
    public Task<CpuDTO> Add(AddCpuDTO post);
    public Task Update(CpuDTO updateCpu);
    public Task Delete(int id);

    public Task<List<SocketCpuDTO>> GetAllSockets();
    public Task<SocketCpuDTO> GetSocketById(int id);
    public Task<SocketCpuDTO> AddSocket(AddSocketCpuDTO post);
    public Task UpdateSocket(SocketCpuDTO updateCpu);
    public Task DeleteSocket(int id);
}
