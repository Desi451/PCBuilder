using System.ComponentModel.DataAnnotations;

namespace Application.DTO.Components.RAM;

public class RamDTO
{
    [Range(1, int.MaxValue)]
    public int Id { get; set; }
    [Required]
    [StringLength(200, MinimumLength = 1)]
    public string Name { get; set; }
    [Required]
    [StringLength(200, MinimumLength = 1)]
    public string Model { get; set; }
    [Range(1, int.MaxValue)]
    public int Capacity { get; set; }
    [Range(1, int.MaxValue)]
    public int NoElements { get; set; }
    [Required]
    [StringLength(2000)]
    public string Description { get; set; }
    [Required]
    [StringLength(200)]
    public string Latency { get; set; }
    public int BrandId { get; set; }
    [Range(1, int.MaxValue)]
    public int MemorySpeedId { get; set; }
    [Range(1, int.MaxValue)]
    public int SeriesId { get; set; }
}
