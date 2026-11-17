using System.ComponentModel.DataAnnotations;

namespace Application.DTO.Components.CPU;

public class AddSocketCpuDTO
{
    [Required]
    [StringLength(200, MinimumLength = 1)]
    public string Name { get; set; }
    [Range(1, int.MaxValue)]
    public int BrandId { get; set; }
}
