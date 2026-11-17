using System.ComponentModel.DataAnnotations;

namespace Application.DTO.Computer;

public class CaseRequest
{
    [Range(1, int.MaxValue)]
    public int MotherboardId { get; set; }

    [Range(1, int.MaxValue)]
    public int PsuId { get; set; }

    [Range(1, int.MaxValue)]
    public int? GpuId { get; set; }
}
