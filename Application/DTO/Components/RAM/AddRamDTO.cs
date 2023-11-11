namespace Application.DTO.Components.RAM;

public class AddRamDTO
{
    public string Name { get; set; }
    public string Model { get; set; }
    public int Capacity { get; set; }
    public int NoELements { get; set; }
    public string Description { get; set; }
    public string Latency { get; set; }
    public int BrandId { get; set; }
    public int MemorySpeedId { get; set; }
    public int SeriesId { get; set; }
}
