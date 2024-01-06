using Domain.Entities.Components.Drives;

namespace Domain.Entities.Computer;

public class ComputerSsds
{
    public int Id { get; set; }

    public int SsdId { get; set; }
    public Ssd? Ssd { get; set; }

    public int ComputerId { get; set; }
    public Computer? Computer { get; set; }
}
