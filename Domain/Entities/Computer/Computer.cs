using Domain.Common;
using Domain.Entities.Components;
using Domain.Entities.Components.Case;
using Domain.Entities.Components.CPU;
using Domain.Entities.Components.Drives;
using Domain.Entities.Components.GPU;
using Domain.Entities.Components.Motherboard;
using Domain.Entities.Components.RamMemory;

namespace Domain.Entities.Computer;

public class Computer : AuditableEntity
{
    public required int Id { get; set; }
    public required int UserId { get; set; }
    public required string Name { get; set; }

    public required int CaseId { get; set; }
    public required int CpuId { get; set; }
    public required int MotherboardId { get; set; }
    public required int RamMemoryId { get; set; }
    public required int PsuId { get; set; }
    public int GpuId { get; set; }


    public User User { get; set; }
    public Case Case { get; set; }
    public CPU Cpu { get; set; }
    public Motherboard Mobo { get; set; }
    public RamMemories RamMemory { get; set; }
    public PowerSupply Psu { get; set; }
    public GPU Gpu { get; set; }

    public List<Hdd> Drives { get; set; }
    public List<Ssd> Ssds { get; set; }
}
