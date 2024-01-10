using Application.DTO.BrandDTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.Common;
using Domain.Interfaces.Repository;
using System.Net.Http;

namespace Application.Service;

public class BrandService : IBrandService
{
    private IBrandRepository _repository;
    private readonly ISaveData _saveData;
    private readonly IMapper _mapper;

    public BrandService(
        IBrandRepository repository,
        ISaveData saveData,
        IMapper mapper)
    {
        _repository = repository;
        _saveData = saveData;
        _mapper = mapper;
    }

    public async Task<BrandDTO> Add(AddBrandDTO brand)
    {
        var res = _mapper.Map<Brand>(brand);
        await _repository.Add(res);
        await _saveData.Save();
        return _mapper.Map<BrandDTO>(res);
    }

    public async Task Delete(int id)
    {
        await _repository.Delete(id);
        await _saveData.Save();
    }

    public async Task Update(BrandDTO updateBrand)
    {
        try
        {
            var res = _mapper.Map<Brand>(updateBrand);
            await _repository.Update(res);
            await _saveData.Save();
        }
        catch
        {
            throw;
        }
    }

    public async Task<List<BrandDTO>> GetAll()
    {
        var res = await _repository.GetBrands();
        return _mapper.Map<List<BrandDTO>>(res);
    }

    public async Task<BrandDTO> GetById(int id)
    {
        var res = await _repository.GetById(id);
        return _mapper.Map<BrandDTO>(res);
    }
}
