using Application.DTO.Components.Case;
using Application.DTO.Components.Case_Size;
using Application.DTO.Components.PowerSupllyDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Components;

public interface IPowerSupplyService
{
    public Task<List<PowerSupplyDTO>> GetAll();
    public Task<PowerSupplyDTO> GetById(int id);
    public Task<PowerSupplyDTO> Add(AddPowerSupplyDTO psu);
    public Task Update(PowerSupplyDTO upPsu);
    public Task Delete(int id);
}
