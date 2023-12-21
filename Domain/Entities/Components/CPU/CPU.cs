using Domain.Common;

namespace Domain.Entities.Components.CPU;

public class CPU : AuditableEntity
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Model { get; set; }
    public required int Cores { get; set; }
    public required int Threads { get; set; }
    public required double MinFreq { get; set; }
    public required double MaxFreq { get; set; }
    public required int L2Cache { get; set; }
    public required int L3Cache { get; set; }
    public required int MaxRam { get; set; }
    public required bool IsAPU { get; set; }
    public required int Technology { get; set; } //nm
    public required int TDP { get; set; }
    public required int SeriesId { get; set; }
    public required int SocketCPUId { get; set; }
    public required string Description { get; set; }

    public Series Series { get; set; }
    public SocketCPU SocketCPU { get; set; }
}
