using Domain.Common;

namespace Domain.Entities.Components.CPU;

public class SocketCPU : AuditableEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
}
