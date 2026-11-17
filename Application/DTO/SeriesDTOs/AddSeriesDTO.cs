using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Application.DTO.SeriesDTOs;

public class AddSeriesDTO
{
    [Required]
    [StringLength(200, MinimumLength = 1)]
    public string Name { get; set; }
    [Range(1, int.MaxValue)]
    public int BrandId { get; set; }
}
