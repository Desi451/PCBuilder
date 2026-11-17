using System.ComponentModel.DataAnnotations;

namespace Application.DTO.Components.Drive;

public class AddSsdDTO
{
    [Required]
    [StringLength(200, MinimumLength = 1)]
    public string Name { get; set; }
    [Required]
    [StringLength(200, MinimumLength = 1)]
    public string Model { get; set; }
    [Required]
    [StringLength(2000)]
    public string Description { get; set; }
    [Range(0d, double.MaxValue, MinimumIsExclusive = true)]
    public double Capacity { get; set; }
    [Range(1, int.MaxValue)]
    public int MaxRead { get; set; }
    [Range(1, int.MaxValue)]
    public int MaxWrite { get; set; }

    [Range(1, int.MaxValue)]
    public int SlotInterfaceId { get; set; }
    [Range(1, int.MaxValue)]
    public int SeriesId { get; set; }
}
