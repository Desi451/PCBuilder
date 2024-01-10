using Domain.Entities.Slots;

namespace Domain.Interfaces.Repository;

public interface ISlotRepository
{
    Task Add(SlotInterface slot);
    Task Update(SlotInterface slot);
    Task Delete(int id);

    //query
    Task<List<SlotInterface>> Get();
    Task<SlotInterface> GetById(int id);
}
