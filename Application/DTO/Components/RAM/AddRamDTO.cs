using System.ComponentModel.DataAnnotations;

namespace Application.DTO.Components.RAM;

public class AddRamDTO
{
    [Required]
    [StringLength(200, MinimumLength = 1)]
    public string Name { get; set; }
    [Required]
    [StringLength(200, MinimumLength = 1)]
    public string Model { get; set; }
    [Range(1, int.MaxValue)]
    public int Capacity { get; set; }
    [Range(1, int.MaxValue)]
    public int NoELements { get; set; }
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
