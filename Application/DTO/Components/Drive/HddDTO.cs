namespace Application.DTO.Components.Drive;

public class HddDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Model { get; set; }
    public string Description { get; set; }
    public double Capacity { get; set; }
    public int Rpm { get; set; }
    public double Cache { get; set; }

    public int SlotInterfaceId { get; set; }
    public int SeriesId { get; set; }
}
