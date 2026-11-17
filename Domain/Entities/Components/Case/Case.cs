using Domain.Common;

namespace Domain.Entities.Components.Case;

public class Case : AuditableEntity
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Model { get; set; }
    public required float Height { get; set; }
    public required float Width { get; set; }
    public required float Deepth { get; set; }
    public required string Description { get; set; }

    //relations
    public required int SeriesId { get; set; }
    public CaseSize CaseSize { get; set; }
    public Series Series { get; set; }
}
