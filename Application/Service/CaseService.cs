using Application.DTO.Components.Case;
using Application.DTO.Components.Case_Size;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities.Components.Case;
using Domain.Interfaces.Common;
using Domain.Interfaces.Repository;

namespace Application.Service;

public class CaseService : ICaseService
{
    private ICaseRepository _repo;
    private readonly ISaveData _saveData;
    private readonly IMapper _mapper;

    public CaseService(ICaseRepository repo, ISaveData saveData, IMapper mapper)
    {
        _repo = repo;
        _saveData = saveData;
        _mapper = mapper;
    }

    public async Task<CaseDTO> Add(AddCaseDTO box)
    {
        var res = _mapper.Map<Case>(box);
        await _repo.Add(res);
        await _saveData.Save();
        return _mapper.Map<CaseDTO>(res);
    }

    public async Task Delete(int id)
    {
        await _repo.Delete(id);
        await _saveData.Save();
    }

    public async Task<List<CaseDTO>> GetAll()
    {
        var res = await _repo.GetCases();
        return _mapper.Map<List<CaseDTO>>(res);
    }

    public async Task<CaseDTO> GetById(int id)
    {
        var res = await _repo.GetById(id);
        return _mapper.Map<CaseDTO>(res);
    }

    public async Task Update(CaseDTO upBox)
    {
        try
        {
            var res = _mapper.Map<Case>(upBox);
            await _repo.Update(res);
            await _saveData.Save();
        }
        catch
        {
            throw;
        }
    }
}
