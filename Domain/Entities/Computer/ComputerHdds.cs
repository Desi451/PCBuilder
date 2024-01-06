using Domain.Entities.Components.Drives;

namespace Domain.Entities.Computer;

public class ComputerHdds
{
    public int Id { get; set; }

    public int HddId { get; set; }
    public Hdd? Hdd { get; set; }

    public int ComputerId { get; set; }
    public Computer? Computer { get; set; }
}
