using Application.DTO.Components.GPU;

namespace Application.Interfaces.Components;

public interface IGpuService
{
    public Task<List<GpuDTO>> GetAll();
    public Task<GpuDTO> GetById(int id);
    public Task<GpuDTO> Add(AddGpuDTO post);
    public Task Update(GpuDTO updateCpu);
    public Task Delete(int id);
}
