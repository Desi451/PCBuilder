using Domain.Entities.Components.Case;
using Domain.Entities.Components.CPU;
using Domain.Entities.Components.Drives;
using Domain.Entities.Components.GPU;
using Domain.Entities.Components.Motherboard;
using Application.DTO.Components.Case_Size;
using Application.DTO.Components.CPU;
using Application.DTO.Components.Motherboard;
using Application.DTO.Components.RAM;
using Application.DTO.Components.PowerSupllyDTOs;
using Application.DTO.Components.GPU;
using Application.DTO.Components.Drive;
using Domain.Entities;
using Application.DTO.BrandDTOs;

namespace Application.DTO.Computer;

public class ComputerFormDTO
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public bool isCompleted { get; set; }
    public CaseDTO Case { get; set; }
    public CpuDTO Cpu { get; set; }
    public MotherboardDTO Mobo { get; set; }
    public RamDTO RamMemory { get; set; }
    public PowerSupplyDTO Psu { get; set; }
    public GpuDTO Gpu { get; set; }

    public BrandDTO cpuBrand { get; set; }

    public List<HddDTO> Drives { get; set; }
    public List<SsdDTO> Ssds { get; set; }
}
