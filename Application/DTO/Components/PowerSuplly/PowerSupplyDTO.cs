namespace Application.DTO.Components.PowerSupllyDTOs;

public class PowerSupplyDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Model { get; set; }
    public string standard { get; set; }
    public int Power { get; set; }
    public string Fans { get; set; }
    public bool HasPFC { get; set; }
    public string MainConnPins { get; set; }
    public string PCIExpressConn { get; set; }
    public bool HasSLI { get; set; }
    public bool HasCrossFire { get; set; }
    public string Voltage { get; set; }
    public string Freq { get; set; }
    public string Connectors { get; set; }
    public string Description { get; set; }
    public string Dimensions { get; set; }
    public int SeriesId { get; set; }
}
