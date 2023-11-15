using Domain.Common;
using Domain.Entities.Components.Case;
using Domain.Entities.Components.CPU;

namespace Domain.Entities.Components.Motherboard;

public class Motherboard : AuditableEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Model { get; set; }
    public int BrandId { get; set; }
    public int SeriesId { get; set; }
    public int SocketCPUId { get; set; }
    public string Chipset { get; set; }
    public int MaxMemory { get; set; }
    public int SATASlots { get; set; }
    public int M2Slots { get; set; }
    public int CaseSizeId { get; set; }
    public string Description { get; set; }

    public CaseSize CaseSize { get; set; }
    public Brand Brand { get; set; }
    public Series Series { get; set; }
    public SocketCPU SocketCPU { get; set; }
    public List<MotheboardMemory> Memories { get; set; }
}
