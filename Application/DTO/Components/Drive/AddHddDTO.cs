using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Application.DTO.Components.Drive;

public class AddHddDTO
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
    public int Rpm { get; set; }
    [Range(0d, double.MaxValue)]
    public double Cache { get; set; }

    [Range(1, int.MaxValue)]
    public int SlotInterfaceId { get; set; }
    [Range(1, int.MaxValue)]
    public int SeriesId { get; set; }
}
