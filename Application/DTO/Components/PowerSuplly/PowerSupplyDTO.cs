namespace Application.DTO.Components.PowerSupllyDTOs;

public class PowerSupplyDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Model { get; set; }
    public string type { get; set; }
    public int maxPower { get; set; }
    public int Fans { get; set; }
    public bool HasPFC { get; set; }
    public int MainConnPins { get; set; }
    public string PCIExpressConn { get; set; }
    public bool HasSLI { get; set; }
    public bool HasCrossFire { get; set; }
    public double Voltage { get; set; }
    public int Freq { get; set; }
    public string Connectors { get; set; }
    public string Description { get; set; }
    public string Dimensions { get; set; }
    public int BrandId { get; set; }
    public int SeriesId { get; set; }
}
