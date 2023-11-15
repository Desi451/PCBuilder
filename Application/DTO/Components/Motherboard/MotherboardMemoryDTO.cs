using Domain.Entities.Components.RamMemory;

namespace Application.DTO.Components.Motherboard;

public class MotherboardMemoryDTO
{
    public int Id { get; set; }

    public int RamMemoryId { get; set; }
    public RamMemories? Memory { get; set; }
}
