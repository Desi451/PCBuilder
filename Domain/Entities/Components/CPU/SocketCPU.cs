using Domain.Common;

namespace Domain.Entities.Components.CPU;

public class SocketCPU : AuditableEntity
{
    public int Id { get; set; }
    public required string Name { get; set; }

    public required int BrandId { get; set; }
    public Brand Brand { get; set; }
}
