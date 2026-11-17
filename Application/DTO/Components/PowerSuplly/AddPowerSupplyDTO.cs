using Application.Service.Compatibility;
using System.ComponentModel.DataAnnotations;

namespace Application.DTO.Components.PowerSupllyDTOs;

public class AddPowerSupplyDTO
{
    [Required]
    [StringLength(200, MinimumLength = 1)]
    public string Name { get; set; }
    [Required]
    [StringLength(200, MinimumLength = 1)]
    public string Model { get; set; }
    [Required]
    [RegularExpression(CompatibilityRules.PsuStandardPattern, ErrorMessage = "Standard must be one of: EATX, ATX, ITXMicroATX, ITX, SFX, SFX-L.")]
    public string standard { get; set; }
    [Range(1, int.MaxValue)]
    public int Power { get; set; }
    [Required]
    [StringLength(200)]
    public string Fans { get; set; }
    public bool HasPFC { get; set; }
    [Required]
    [StringLength(200)]
    public string MainConnPins { get; set; }
    [Required]
    [StringLength(200)]
    public string PCIExpressConn { get; set; }
    public bool HasSLI { get; set; }
    public bool HasCrossFire { get; set; }
    [Required]
    [StringLength(200)]
    public string Voltage { get; set; }
    [Required]
    [StringLength(200)]
    public string Freq { get; set; }
    [Required]
    [StringLength(200)]
    public string Connectors { get; set; }
    [Required]
    [StringLength(2000)]
    public string Description { get; set; }
    [Required]
    [StringLength(200)]
    public string Dimensions { get; set; }
    [Range(1, int.MaxValue)]
    public int SeriesId { get; set; }
}
