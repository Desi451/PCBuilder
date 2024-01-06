using Application.DTO.BrandDTOs;

namespace Application.Interfaces;

public interface IBrandService
{
    public Task<List<BrandDTO>> GetAll();
    public Task<BrandDTO> GetById(int id);
    public Task<BrandDTO> Add(AddBrandDTO post);
    public Task Update(BrandDTO updateBrand);
    public Task Delete(int id);
}
