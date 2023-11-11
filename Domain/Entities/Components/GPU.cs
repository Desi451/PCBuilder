using Domain.Common;

namespace Domain.Entities.Components;

public class GPU : AuditableEntity
{
    public int Id { get; set; }
    public int BrandId { get; set; }
    public int SeriesId { get; set; }
    public string Name { get; set; }
    public int SlotInterfaceId { get; set; }
    public int ChipsetBrandId { get; set; }
    public int ModelSeriesId { get; set; }
    public string CoreClock { get; set; }
    public int MemorySize { get; set; }
    public int MemoryInterface { get; set; } //szyna
    public string MemoryType { get; set; }
    public string DirectX { get; set; }
    public double OpenGL { get; set; }
    public int TDP { get; set; }
    public int RecommendedPsuPower { get; set; }
    public int CaseSizeId { get; set; }
    public int Length { get; set; }
    public string Description { get; set; }
}
