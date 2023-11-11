using Application.DTO.BrandDTOs;
using Application.DTO.Components.CPU;
using Application.DTO.Components.RAM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Components;

public interface IRAMService
{
    public Task<List<RamDTO>> GetAll();
    public Task<RamDTO> GetById(int id);
    public Task<RamDTO> Add(AddRamDTO post);
    public Task Update(RamDTO updateCpu);
    public Task Delete(int id);

    public Task<List<RamSpeedDTO>> GetAllSpeed();
    public Task<RamSpeedDTO> GetSpeedById(int id);
    public Task<RamSpeedDTO> AddSpeed(AddRamSpeedDTO post);
    public Task UpdateSpeed(RamSpeedDTO ram);
    public Task DeleteSpeed(int id);
}
