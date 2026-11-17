using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Application.DTO.Components.Slot;

public class AddSlotDTO
{
    [Required]
    [StringLength(200, MinimumLength = 1)]
    public required string Name { get; set; }
}
