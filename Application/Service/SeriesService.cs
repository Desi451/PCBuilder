using Application.DTO.SeriesDTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.Common;
using Domain.Interfaces.Repository;

namespace Application.Service;

public class SeriesService : ISeriesService
{
    private readonly ISeriesRepository _repository;
    private readonly ISaveData _saveData;
    private readonly IMapper _mapper;

    public SeriesService(
        ISeriesRepository repository,
        ISaveData saveData,
        IMapper mapper)
    {
        _repository = repository;
        _saveData = saveData;
        _mapper = mapper;
    }

    public async Task<SeriesDTO> Add(AddSeriesDTO series)
    {
        var res = _mapper.Map<Series>(series);
        await _repository.Add(res);
        await _saveData.Save();
        return _mapper.Map<SeriesDTO>(res);
    }

    public async Task Delete(int id)
    {
        await _repository.Delete(id);
        await _saveData.Save();
    }

    public async Task Update(SeriesDTO updateSeries)
    {
        try
        {
            var res = _mapper.Map<Series>(updateSeries);
            await _repository.Update(res);
            await _saveData.Save();
        }
        catch
        {
            throw;
        }
    }

    public async Task<List<SeriesDTO>> GetAll()
    {
        var res = await _repository.GetSeries();
        return _mapper.Map<List<SeriesDTO>>(res);
    }

    public async Task<SeriesDTO> GetById(int id)
    {
        var res = await _repository.GetById(id);
        return _mapper.Map<SeriesDTO>(res);
    }
}
