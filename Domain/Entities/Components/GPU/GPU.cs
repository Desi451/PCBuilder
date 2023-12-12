using Domain.Common;

namespace Domain.Entities.Components.GPU;

public class GPU : AuditableEntity
{
    public int Id { get; set; }
    public int BrandId { get; set; } // Producent gpu
    public int ChipsetBrandId { get; set; }   // Producent chipsetu

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

    public Brand Brand { get; set; } // Producent procesora
    public Brand ChipsetBrand { get; set; }  // Producent chipsetu

    public Series Series { get; set; }
    public Series ChipsetSeries { get; set; }

    public List<SlotInterface> Slots { get; set; }
}
