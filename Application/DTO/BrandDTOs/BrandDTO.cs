using System.ComponentModel.DataAnnotations;

namespace Application.DTO.BrandDTOs;

public class BrandDTO
{
    [Range(1, int.MaxValue)]
    public int Id { get; set; }
    [Required]
    [StringLength(200, MinimumLength = 1)]
    public string Name { get; set; }
}
