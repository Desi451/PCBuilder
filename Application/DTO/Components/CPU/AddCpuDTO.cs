using System.ComponentModel.DataAnnotations;

namespace Application.DTO.Components.CPU;
public class AddCpuDTO
{
    [Required]
    [StringLength(200, MinimumLength = 1)]
    public string Name { get; set; }
    [Required]
    [StringLength(200, MinimumLength = 1)]
    public string Model { get; set; }
    [Range(1, int.MaxValue)]
    public int Cores { get; set; }
    [Range(1, int.MaxValue)]
    public int Threads { get; set; }
    [Range(0d, double.MaxValue, MinimumIsExclusive = true)]
    public double MinFreq { get; set; }
    [Range(0d, double.MaxValue, MinimumIsExclusive = true)]
    public double MaxFreq { get; set; }
    [Range(1, int.MaxValue)]
    public int L2Cache { get; set; }
    [Range(0, int.MaxValue)]
    public int L3Cache { get; set; }
    [Range(1, int.MaxValue)]
    public int MaxRam { get; set; }
    public bool IsAPU { get; set; }
    [Range(1, int.MaxValue)]
    public int Technology { get; set; } //nm
    [Range(1, int.MaxValue)]
    public int TDP { get; set; }
    [Range(1, int.MaxValue)]
    public int SeriesId { get; set; }
    [Range(1, int.MaxValue)]
    public int SocketCpuId { get; set; }
    [Required]
    [StringLength(2000)]
    public string Description { get; set; }
}
