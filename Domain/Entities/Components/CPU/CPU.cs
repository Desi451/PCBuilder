using Domain.Common;

namespace Domain.Entities.Components.CPU;

public class CPU : AuditableEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Model { get; set; }
    public int Cores { get; set; }
    public int Threads { get; set; }
    public double MinFreq { get; set; }
    public double MaxFreq { get; set; }
    public int L2Cache { get; set; }
    public int L3Cache { get; set; }
    public int MaxRam { get; set; }
    public bool IsAPU { get; set; }
    public int Technology { get; set; } //nm
    public int TDP { get; set; }
    public int SeriesId { get; set; }
    public int SocketCPUId { get; set; }
    public string Description { get; set; }

    public Series Series { get; set; }
    public SocketCPU SocketCPU { get; set; }
}
