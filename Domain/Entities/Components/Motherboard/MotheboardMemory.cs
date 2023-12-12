using Domain.Common;
using Domain.Entities.Components.RamMemory;

namespace Domain.Entities.Components.Motherboard;

public class MotheboardMemory
{
    public int Id { get; set; }

    public int MemoryId { get; set; }
    public RamSpeed? Memory { get; set; }
        
    public int MotherBoardId { get; set; }
    public Motherboard? Motherboard { get; set; }
}
