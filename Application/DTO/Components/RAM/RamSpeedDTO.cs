using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Application.DTO.Components.RAM;

public class RamSpeedDTO
{
    [Range(1, int.MaxValue)]
    public int Id { get; set; }
    [Required]
    [StringLength(50, MinimumLength = 1)]
    public required string Standard { get; set; }
    [Range(1, int.MaxValue)]
    public int Freq { get; set; }
}
