using Application.DTO.BrandDTOs;
using Application.DTO.Components.Case_Size;
using Application.DTO.Components.CPU;
using Application.DTO.Components.Motherboard;
using Application.DTO.Components.PowerSupllyDTOs;
using Application.DTO.Components.RAM;
using Application.DTO.Computer;
using Domain.Entities.Components.RamMemory;
using Domain.Entities.Computer;

namespace Application.Interfaces;
public interface IComputerService
{
    public Task Add(AddComputerDTO pc);
    public Task Update(ComputerDTO pc);
    public Task Delete(int id);

    //query
    public Task<List<ComputerDTO>> GetComputers();
    public Task<List<ComputerViewDTO>> GetComputersView();
    public Task<List<ComputerViewDTO>> GetComputersViewByUser(int id);
    public Task<ComputerDTO> GetById(int id);
    public Task<ComputerFormDTO> GetFullDataById(int id);

    public Task<List<BrandDTO>> GetCpuBrands();
    public Task<List<CpuDTO>> GetCPUsByBrandId(int brandId);
    public Task<List<MotherboardDTO>> GetMotherBoardsBySocket(int socketId);
    public Task<List<RamDTO>> GetRamsByMotherboard(int motherboardId);
    public Task<List<PowerSupplyDTO>> GetPsuByWattage(int wattage);
    public Task<List<CaseDTO>> GetCasesByStandard(int caseSizeId, double gpuLength);
}
