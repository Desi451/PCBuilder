using Domain.Common;

namespace Domain.Entities.Components.RamMemory;

public class RamMemories : AuditableEntity
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Model { get; set; }
    public required int Capacity { get; set; }
    public required int NoELements { get; set; }
    public required string Description { get; set; }
    public required string Latency { get; set; }
    public required int MemorySpeedId { get; set; }
    public required int SeriesId { get; set; }

    public Series series { get; set; }
    public RamSpeed MemorySpeed { get; set; }
}
