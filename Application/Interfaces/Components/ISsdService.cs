using Application.DTO.Components.Drive;

namespace Application.Interfaces.Components;

public interface ISsdService
{
    public Task<List<SsdDTO>> GetAll();
    public Task<SsdDTO> GetById(int id);
    public Task<SsdDTO> Add(AddSsdDTO ssd);
    public Task Update(SsdDTO ssd);
    public Task Delete(int id);
}
