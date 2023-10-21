namespace Application.DTO.Components.Case;

public class AddCaseDTO
{
    public required string Name { get; set; }
    public required string Model { get; set; }
    public float Height { get; set; }
    public float Width { get; set; }
    public float Deepth { get; set; }
    public required string Description { get; set; }
    public int CaseSizeId { get; set; }
    public int BrandId { get; set; }
    public int SeriesId { get; set; }
}
