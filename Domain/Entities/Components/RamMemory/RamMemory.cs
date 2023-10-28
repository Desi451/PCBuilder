using Domain.Common;

namespace Domain.Entities.Components.RamMemory;

public class RamMemory : AuditableEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Model { get; set; }
    public int Capacity { get; set; }
    public int NoELements { get; set; }
    public string Description { get; set; }
    public string Latency { get; set; }
    public int BrandId { get; set; }

    public MemorySpeed MemorySpeed { get; set; }
    public Brand Brand { get; set; }
}
