namespace Application.DTO.Components.CPU;
public class AddCpuDTO
{
    public string Name { get; set; }
    public string Model { get; set; }
    public int Cores { get; set; }
    public int Threads { get; set; }
    public int MinFreq { get; set; }
    public int MaxFreq { get; set; }
    public int L2Cache { get; set; }
    public int L3Cache { get; set; }
    public int MaxRam { get; set; }
    public bool IsAPU { get; set; }
    public int Technology { get; set; } //nm
    public int TDP { get; set; }
    public int BrandId { get; set; }
    public int SeriesId { get; set; }
    public int SocketCPUId { get; set; }
    public string Description { get; set; }
}
