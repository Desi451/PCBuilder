using Domain.Entities;
using Domain.Entities.Components;
using Domain.Entities.Components.Case;
using Domain.Entities.Components.CPU;
using Domain.Entities.Components.Drives;
using Domain.Entities.Components.GPU;
using Domain.Entities.Components.Motherboard;
using Domain.Entities.Components.RamMemory;
using Domain.Entities.Computer;

namespace Domain.Interfaces.Repository;

public interface IComputerRepository
{
    Task Add(Computer computer, List<Hdd> Hdds, List<Ssd> Ssds);
    Task Update(Computer computer, List<Hdd> Hdds, List<Ssd> Ssds);
    Task Delete(int id);

    //query
    Task<List<Computer>> GetComputers();
    Task<Computer> GetById(int id);

    Task<Computer> GetFullDataById(int id);
    Task<List<Computer>> GetComputersView();
    Task<List<Computer>> GetComputersViewByUser(int id);
    //elements
    Task AddHdd(ComputerHdds hdd);
    Task AddSsd(ComputerSsds hdd);
    Task DeleteHdd(int id);
    Task DeleteSsd(int id);

    //building PC
    Task<List<Brand>> GetBrandsForCPUSocketsAsync();
    Task<List<CPU>> GetCPUsByBrandIdAsync(int brandId);
    Task<List<Motherboard>> GetMotherBoardsBySocket(int socketId);
    Task<List<RamMemories>> GetRamsByMotherboard(int motherboardId);
    Task<List<PowerSupply>> GetPsusByWattage(int watt);
    Task<List<Case>> GetCasesBySize(CaseSize maxCaseSize, int minDepthMm);

    //compatibility (soft-deleted components included)
    Task<Case?> FindCase(int id);
    Task<CPU?> FindCpu(int id);
    Task<Motherboard?> FindMotherboard(int id);
    Task<RamMemories?> FindRam(int id);
    Task<PowerSupply?> FindPsu(int id);
    Task<GPU?> FindGpu(int id);
    Task<List<Hdd>> FindHdds(List<int> ids);
    Task<List<Ssd>> FindSsds(List<int> ids);
    Task<List<int>> GetHddIds(int computerId);
    Task<List<int>> GetSsdIds(int computerId);
}
