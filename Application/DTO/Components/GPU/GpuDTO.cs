using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.Components.GPU;

public class GpuDTO
{
    public int Id { get; set; }

    public int SeriesId { get; set; }
    public int ChipsetSeriesId { get; set; }   // Seria chipsetu
    public string Name { get; set; }
    public int CoresetId { get; set; }
    public string CoreClock { get; set; }
    public int MemorySize { get; set; }
    public int MemoryInterface { get; set; } //szyna
    public string MemoryType { get; set; }
    public string DirectX { get; set; }
    public double OpenGL { get; set; }
    public int TDP { get; set; }
    public int RecommendedPsuPower { get; set; }
    public int Length { get; set; }
    public string Description { get; set; }
}
