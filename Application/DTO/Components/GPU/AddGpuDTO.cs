using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Application.DTO.Components.GPU;

public class AddGpuDTO
{
    [Range(1, int.MaxValue)]
    public int SeriesId { get; set; }
    [Range(1, int.MaxValue)]
    public int ChipsetSeriesId { get; set; }   // Seria chipsetu
    [Required]
    [StringLength(200, MinimumLength = 1)]
    public string Name { get; set; }
    public int CoresetId { get; set; }
    [Required]
    [StringLength(200)]
    public string CoreClock { get; set; }
    [Range(1, int.MaxValue)]
    public int MemorySize { get; set; }
    [Range(1, int.MaxValue)]
    public int MemoryInterface { get; set; } //szyna
    [Required]
    [StringLength(200)]
    public string MemoryType { get; set; }
    [Required]
    [StringLength(200)]
    public string DirectX { get; set; }
    [Range(0d, double.MaxValue, MinimumIsExclusive = true)]
    public double OpenGL { get; set; }
    [Range(1, int.MaxValue)]
    public int TDP { get; set; }
    [Range(1, int.MaxValue)]
    public int RecommendedPsuPower { get; set; }
    [Range(1, int.MaxValue)]
    public int Length { get; set; }
    [Required]
    [StringLength(2000)]
    public string Description { get; set; }
}
