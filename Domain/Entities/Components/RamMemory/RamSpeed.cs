using Domain.Common;

namespace Domain.Entities.Components.RamMemory;

public class RamSpeed : AuditableEntity
{
    public int Id { get; set; }
    public required string Standard { get; set; }
    public required int Freq { get; set; }
}
