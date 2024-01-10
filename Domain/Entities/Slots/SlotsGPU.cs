using Domain.Entities.Components.GPU;

namespace Domain.Entities.Slots;

public class SlotsGPU
{
    public int Id { get; set; }

    public int SlotId { get; set; }
    public SlotInterface? Slot { get; set; }

    public int GpuId { get; set; }
    public GPU? Gpu { get; set; }
}
