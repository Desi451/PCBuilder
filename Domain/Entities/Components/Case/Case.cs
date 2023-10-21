using Domain.Common;

namespace Domain.Entities.Components.Case;

public class Case : AuditableEntity
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Model {  get; set; }
    //public int SmallDriverBays {  get; set; }
    //public int LargeDriverBays { get; set; }
    public float Height { get; set; }
    public float Width { get; set; }
    public float Deepth { get; set; }
    public required string Description { get; set; }

    //relations
    public int CaseSizeId { get; set; }
    public int BrandId { get; set; }
    public int SeriesId { get; set; }
    public CaseSize CaseSize { get; set; }
    public Brand Brand { get; set; }
    public Series Series { get; set; }
}
