using Domain.Common;

namespace Domain.Entities.Slots;

public class SlotInterface : AuditableEntity
{
    public int Id { get; set; }
    public required string Name { get; set; }
}
