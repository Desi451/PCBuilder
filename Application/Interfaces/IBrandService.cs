using Application.DTO.BrandDTOs;
using Application.DTO.SeriesDTOs;
using Application.DTO.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces;

public interface IBrandService
{
    public Task<List<BrandDTO>> GetAll();
    public Task<BrandDTO> GetById(int id);
    public Task<BrandDTO> Add(AddBrandDTO post);
    public Task Update(BrandDTO updateBrand);
    public Task Delete(int id);
}
