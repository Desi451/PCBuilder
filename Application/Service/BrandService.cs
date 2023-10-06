using Application.DTO.BrandDTOs;
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

public class BrandService : IBrandService
{
    private readonly IBrandQuery _query;
    private IBrandRepository _repository;
    private readonly IMapper _mapper;

    public BrandService(IBrandQuery query, IBrandRepository repository,
        IMapper mapper)
    {
        _query = query;
        _repository = repository;
        _mapper = mapper;
    }

    public Task<BrandDTO> Add(AddBrandDTO brand)
    {
        throw new NotImplementedException();
    }

    public Task Delete(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<BrandDTO>> GetAll()
    {
        var res = await _query.GetBrands();
        return _mapper.Map<List<BrandDTO>>(res);
    }

    public async Task<BrandDTO> GetById(int id)
    {
        var res = await _query.GetById(id);
        return _mapper.Map<BrandDTO>(res);
    }

    public Task Update(BrandDTO updateBrand)
    {
        throw new NotImplementedException();
    }
}
