using Application.DTO.Components.RAM;

namespace Application.DTO.Components.Motherboard;

public class AddMotherboardMemoryDTO
{
    public int RamMemoryId { get; set; }
    public RamDTO? Memory { get; set; }
}
