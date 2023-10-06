using Application.DTO.SeriesDTOs;
using Application.DTO.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces;

public interface ISeriesService
{
    public Task<List<SeriesDTO>> GetAll();
    public Task<SeriesDTO> GetById(int id);
    public Task<SeriesDTO> Add(AddSeriesDTO post);
    public Task Update(SeriesDTO updateSeries);
    public Task Delete(int id);
}
