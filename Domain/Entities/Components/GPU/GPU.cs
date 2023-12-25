using Domain.Common;
using Domain.Entities.Slots;

namespace Domain.Entities.Components.GPU;

public class GPU : AuditableEntity
{
    public int Id { get; set; }

    public int SeriesId { get; set; }
    public int ChipsetSeriesId { get; set; }   // Seria chipsetu
    public required string Name { get; set; }
    public required int CoresQuantity { get; set; }
    public required string CoreClock { get; set; }
    public required int MemorySize { get; set; }
    public required int MemoryInterface { get; set; } //szyna
    public required string MemoryType { get; set; }
    public required string DirectX { get; set; }
    public required double OpenGL { get; set; }
    public required int TDP { get; set; }
    public required int RecommendedPsuPower { get; set; }
    public required int Length { get; set; }
    public required string Description { get; set; }

    public Series Series { get; set; }
    public Series ChipsetSeries { get; set; }
}
