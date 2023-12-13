using Domain.Common;

namespace Domain.Entities;

public class Series : AuditableEntity
{
    public int Id { get; set; }
    public string Name { get; set; }

    public int BrandId {  get; set; }
    public Brand Brand { get; set; }
}
