using Domain.Common;

namespace Domain.Entities.Components.RamMemory;

public class MemorySpeed : AuditableEntity
{
    public int Id { get; set; }
    public required string Standard { get; set; }
    public int Freq { get; set; }
}
