using Application.DTO.Components.RAM;
using Domain.Entities.Components.RamMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.Components.Motherboard;

public class UpdateMotherboardDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Model { get; set; }
    public int SeriesId { get; set; }
    public int SocketCPUId { get; set; }
    public string Chipset { get; set; }
    public int MaxMemory { get; set; }
    public int SATASlots { get; set; }
    public int M2Slots { get; set; }
    public int CaseSizeId { get; set; }
    public string Description { get; set; }
    public List<RamSpeedDTO> Memories { get; set; }
}
