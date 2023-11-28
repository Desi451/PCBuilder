using Application.DTO.Components.RAM;
using Domain.Entities.Components.RamMemory;

namespace Application.DTO.Components.Motherboard;

public class AddMotherboardMemoryDTO
{
    public int RamMemoryId { get; set; }
    public RamDTO? Memory { get; set; }
}
