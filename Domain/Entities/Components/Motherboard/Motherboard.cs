using Domain.Common;
using Domain.Entities.Components.Case;
using Domain.Entities.Components.CPU;

namespace Domain.Entities.Components.Motherboard;

public class Motherboard : AuditableEntity
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Model { get; set; }
    public required int SeriesId { get; set; }
    public required int SocketCpuId { get; set; }
    public required string Chipset { get; set; }
    public required int MaxMemory { get; set; }
    public required int SATASlots { get; set; }
    public required int M2Slots { get; set; }
    public required int RamSlots { get; set; }
    public required int CaseSizeId { get; set; }
    public required string Description { get; set; }

    public required CaseSize CaseSize { get; set; }
    public required Series Series { get; set; }
    public required SocketCPU SocketCPU { get; set; }
    public required List<MotheboardMemory> Memories { get; set; }
}
