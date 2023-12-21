using Domain.Common;

namespace Domain.Entities;

public class Series : AuditableEntity
{
    public required int Id { get; set; }
    public required string Name { get; set; }

    public required int BrandId {  get; set; }
    public required Brand Brand { get; set; }
}
