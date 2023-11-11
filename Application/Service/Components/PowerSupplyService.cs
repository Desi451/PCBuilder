using Application.DTO.Components.Case_Size;
using Application.DTO.Components.PowerSupllyDTOs;
using Application.Interfaces.Components;
using AutoMapper;
using Domain.Entities.Components;
using Domain.Entities.Components.Case;
using Domain.Interfaces.Common;
using Domain.Interfaces.Repository.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.Components;

public class PowerSupplyService : IPowerSupplyService
{
    private IPowerSupplyRepository _repo;
    private readonly ISaveData _saveData;
    private readonly IMapper _mapper;

    public PowerSupplyService(IPowerSupplyRepository repo, ISaveData saveData, IMapper mapper)
    {
        _repo = repo;
        _saveData = saveData;
        _mapper = mapper;
    }

    public async Task<List<PowerSupplyDTO>> GetAll()
    {
        var res = await _repo.GetPSUs();
        return _mapper.Map<List<PowerSupplyDTO>>(res);
    }

    public async Task<PowerSupplyDTO> GetById(int id)
    {
        var res = await _repo.GetById(id);
        return _mapper.Map<PowerSupplyDTO>(res);
    }

    public async Task<PowerSupplyDTO> Add(AddPowerSupplyDTO psu)
    {
        var res = _mapper.Map<PowerSupply>(psu);
        await _repo.Add(res);
        await _saveData.Save();
        return _mapper.Map<PowerSupplyDTO>(res);
    }

    public async Task Update(PowerSupplyDTO upPsu)
    {
        try
        {
            var res = _mapper.Map<PowerSupply>(upPsu);
            await _repo.Update(res);
            await _saveData.Save();
        }
        catch
        {
            throw;
        }
    }

    public async Task Delete(int id)
    {
        await _repo.Delete(id);
        await _saveData.Save();
    }
}
