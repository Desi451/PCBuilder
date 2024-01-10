using Domain.Common;

namespace Domain.Entities;

public class Brand : AuditableEntity
{
    public required int Id { get; set; }
    public required string Name { get; set; }
}
