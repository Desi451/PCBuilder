using System.ComponentModel.DataAnnotations;

namespace Application.DTO.SeriesDTOs;

public class SeriesDTO
{
    [Range(1, int.MaxValue)]
    public int Id { get; set; }
    [Required]
    [StringLength(200, MinimumLength = 1)]
    public string Name { get; set; }
    [Range(1, int.MaxValue)]
    public int BrandId { get; set; }
}
