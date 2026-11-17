using Application.DTO.Components.Drive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.Computer;

public class AddComputerDTO
{
    public required string Name { get; set; }
    public bool isCompleted { get; set; }

    public required int CaseId { get; set; }
    public required int CpuId { get; set; }
    public required int MotherboardId { get; set; }
    public required int RamMemoryId { get; set; }
    public required int PsuId { get; set; }
    public int? GpuId { get; set; }

    public List<HddDTO> Drives { get; set; }
    public List<SsdDTO> Ssds { get; set; }
}
