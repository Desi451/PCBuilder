using Application.DTO.SeriesDTOs;
using Application.DTO.UserDTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Interfaces.Query;
using Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service;

public class SeriesService : ISeriesService
{
    private readonly ISeriesQuery _query;
    private readonly ISeriesRepository _repository;
    private readonly IMapper _mapper;

    public SeriesService(ISeriesQuery query, ISeriesRepository repository,
        IMapper mapper)
    {
        _query = query;
        _repository = repository;
        _mapper = mapper;
    }

    public Task<SeriesDTO> Add(AddSeriesDTO post)
    {
        throw new NotImplementedException();
    }

    public Task Delete(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<SeriesDTO>> GetAll()
    {
        var res = await _query.GetSeries();
        return _mapper.Map<List<SeriesDTO>>(res);
    }

    public async Task<SeriesDTO> GetById(int id)
    {
        var res = await _query.GetById(id);
        return _mapper.Map<SeriesDTO>(res);
    }

    public Task Update(SeriesDTO updateSeries)
    {
        throw new NotImplementedException();
    }
}
