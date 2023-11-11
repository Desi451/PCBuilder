using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.Components.RAM;

public class RamSpeedDTO
{
    public int Id { get; set; }
    public required string Standard { get; set; }
    public int Freq { get; set; }
}
