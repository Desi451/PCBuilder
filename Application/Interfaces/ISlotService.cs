using Application.DTO.Components.Slot;

namespace Application.Interfaces;

public interface ISlotService
{
    public Task<List<SlotDTO>> GetAll();
    public Task<SlotDTO> GetById(int id);
    public Task<SlotDTO> Add(AddSlotDTO post);
    public Task Update(SlotDTO update);
    public Task Delete(int id);
}
