using Application.DTO.Components.Drive;

namespace Application.DTO.Computer;

public class ComputerDTO
{
    public required int Id { get; set; }
    public required int UserId { get; set; }
    public required string Name { get; set; }

    public required int CaseId { get; set; }
    public required int CpuId { get; set; }
    public required int MotherboardId { get; set; }
    public required int RamMemoryId { get; set; }
    public required int PsuId { get; set; }
    public int GpuId { get; set; }

    public List<HddDTO> Drives { get; set; }
    public List<SsdDTO> Ssds { get; set; }
}
