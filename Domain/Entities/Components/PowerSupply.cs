using Domain.Common;

namespace Domain.Entities.Components;

public class PowerSupply : AuditableEntity
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Model { get; set; }
    public required string type { get; set; }
    public int maxPower { get; set; }
    public required string Fans { get; set; }
    public bool HasPFC { get; set; }
    public required string MainConnPins { get; set; }
    public required string PCIExpressConn { get; set; }
    public bool HasSLI { get; set; }
    public bool HasCrossFire { get; set; }
    public required string Voltage { get; set; }
    public required string Freq { get; set; }
    public required string Connectors { get; set; }
    public required string Description { get; set; }
    public required string Dimensions { get; set; }

    public int BrandId { get; set; }
    public int SeriesId { get; set; }
    public Brand? Brand { get; set; }
    public Series? Series { get; set; }
}
