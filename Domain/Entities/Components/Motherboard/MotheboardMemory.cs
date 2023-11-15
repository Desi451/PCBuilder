using Domain.Common;
using Domain.Entities.Components.RamMemory;

namespace Domain.Entities.Components.Motherboard;

public class MotheboardMemory : AuditableEntity
{
    public int Id { get; set; }

    public int RamMemoryId { get; set; }
    public RamMemories? Memory { get; set; }

    public int MotherBoardId { get; set; }
    public Motherboard? Motherboard { get; set; }
}
