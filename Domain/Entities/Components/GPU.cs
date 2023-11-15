using Domain.Common;

namespace Domain.Entities.Components;

public class GPU : AuditableEntity
{
    public int Id { get; set; }
    public int BrandId { get; set; }
    public int SeriesId { get; set; }
    public required string Name { get; set; }
    public int SlotInterfaceId { get; set; }
    public int ChipsetBrandId { get; set; }
    public int ModelSeriesId { get; set; }
    public required string CoreClock { get; set; }
    public int MemorySize { get; set; }
    public int MemoryInterface { get; set; } //szyna
    public required string MemoryType { get; set; }
    public required string DirectX { get; set; }
    public double OpenGL { get; set; }
    public int TDP { get; set; }
    public int RecommendedPsuPower { get; set; }
    public int CaseSizeId { get; set; }
    public int Length { get; set; }
    public required string Description { get; set; }
}
