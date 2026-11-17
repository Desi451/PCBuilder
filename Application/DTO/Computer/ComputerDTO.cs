using Application.DTO.Components.Drive;
using System.ComponentModel.DataAnnotations;

namespace Application.DTO.Computer;

public class ComputerDTO
{
    [Range(1, int.MaxValue)]
    public required int Id { get; set; }
    public required int UserId { get; set; }
    [Required]
    [StringLength(200, MinimumLength = 1)]
    public required string Name { get; set; }

    [Range(1, int.MaxValue)]
    public required int CaseId { get; set; }
    [Range(1, int.MaxValue)]
    public required int CpuId { get; set; }
    [Range(1, int.MaxValue)]
    public required int MotherboardId { get; set; }
    [Range(1, int.MaxValue)]
    public required int RamMemoryId { get; set; }
    [Range(1, int.MaxValue)]
    public required int PsuId { get; set; }
    [Range(1, int.MaxValue)]
    public int? GpuId { get; set; }

    public List<HddDTO>? Drives { get; set; }
    public List<SsdDTO>? Ssds { get; set; }
}
