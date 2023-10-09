using Domain.Entities;

namespace Domain.Interfaces.Repository;

public interface IBrandRepository
{
    Task Add(Brand brand);
    Task Update(Brand brand);
    Task Delete(int id);

    //query
    Task<List<Brand>> GetBrands();
    Task<Brand> GetById(int id);
}
