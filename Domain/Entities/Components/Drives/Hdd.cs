using Domain.Common;
using Domain.Entities.Slots;

namespace Domain.Entities.Components.Drives;

public class Hdd : AuditableEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Model { get; set; }
    public string Description { get; set; }
    public double Capacity { get; set; }
    public int Rpm { get; set; }
    public double Cache { get; set; }

    public int SlotInterfaceId { get; set; }
    public SlotInterface Slot { get; set; }
    public int SeriesId { get; set; }
    public Series Series { get; set; }
}
