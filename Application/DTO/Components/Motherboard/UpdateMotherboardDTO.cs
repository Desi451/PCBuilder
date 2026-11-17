using Application.DTO.Components.RAM;
using System.ComponentModel.DataAnnotations;

namespace Application.DTO.Components.Motherboard;

public class UpdateMotherboardDTO
{
    [Range(1, int.MaxValue)]
    public int Id { get; set; }
    [Required]
    [StringLength(200, MinimumLength = 1)]
    public string Name { get; set; }
    [Required]
    [StringLength(200, MinimumLength = 1)]
    public string Model { get; set; }
    [Range(1, int.MaxValue)]
    public int SeriesId { get; set; }
    [Range(1, int.MaxValue)]
    public int SocketCPUId { get; set; }
    [Required]
    [StringLength(200)]
    public string Chipset { get; set; }
    [Range(1, int.MaxValue)]
    public int MaxMemory { get; set; }
    [Range(0, int.MaxValue)]
    public int SATASlots { get; set; }
    [Range(0, int.MaxValue)]
    public int M2Slots { get; set; }
    [Range(1, int.MaxValue)]
    public int RamSlots { get; set; }
    [Range(0, 3)]
    public int CaseSizeId { get; set; }
    [Required]
    [StringLength(2000)]
    public string Description { get; set; }
    [Required]
    public List<RamSpeedDTO> Memories { get; set; }
}
