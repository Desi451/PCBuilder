using Application.DTO.Components.Slot;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities.Slots;
using Domain.Interfaces.Common;
using Domain.Interfaces.Repository;

namespace Application.Service;

public class SlotService : ISlotService
{
    private ISlotRepository _repository;
    private readonly ISaveData _saveData;
    private readonly IMapper _mapper;

    public SlotService(
    ISlotRepository repository,
    ISaveData saveData,
    IMapper mapper)
    {
        _repository = repository;
        _saveData = saveData;
        _mapper = mapper;
    }

    public async Task<SlotDTO> Add(AddSlotDTO post)
    {
        var res = _mapper.Map <SlotInterface>(post);
        await _repository.Add(res);
        await _saveData.Save();
        return _mapper.Map<SlotDTO>(res);
    }

    public async Task Delete(int id)
    {
        await _repository.Delete(id);
        await _saveData.Save();
    }

    public async Task<List<SlotDTO>> GetAll()
    {
        var res = await _repository.Get();
        return _mapper.Map<List<SlotDTO>>(res);
    }

    public async Task<SlotDTO> GetById(int id)
    {
        var res = await _repository.GetById(id);
        return _mapper.Map<SlotDTO>(res);
    }

    public async Task Update(SlotDTO update)
    {
        try
        {
            var res = _mapper.Map<SlotInterface>(update);
            await _repository.Update(res);
            await _saveData.Save();
        }
        catch
        {
            throw;
        }
    }
}
