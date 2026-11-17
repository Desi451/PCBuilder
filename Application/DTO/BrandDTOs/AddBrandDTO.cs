using System.ComponentModel.DataAnnotations;

namespace Application.DTO.BrandDTOs;

public class AddBrandDTO
{
    [Required]
    [StringLength(200, MinimumLength = 1)]
    public string Name { get; set; }
}
