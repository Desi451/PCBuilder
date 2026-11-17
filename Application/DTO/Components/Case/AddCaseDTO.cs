using System.ComponentModel.DataAnnotations;

namespace Application.DTO.Components.Case;

public class AddCaseDTO
{
    [Required]
    [StringLength(200, MinimumLength = 1)]
    public required string Name { get; set; }
    [Required]
    [StringLength(200, MinimumLength = 1)]
    public required string Model { get; set; }
    [Range(0d, double.MaxValue, MinimumIsExclusive = true)]
    public float Height { get; set; }
    [Range(0d, double.MaxValue, MinimumIsExclusive = true)]
    public float Width { get; set; }
    [Range(0d, double.MaxValue, MinimumIsExclusive = true)]
    public float Deepth { get; set; }
    [Required]
    [StringLength(2000)]
    public required string Description { get; set; }
    [Range(0, 3)]
    public int CaseSizeId { get; set; }
    [Range(1, int.MaxValue)]
    public int SeriesId { get; set; }
}
