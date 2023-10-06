using Domain.Entities;

namespace Domain.Interfaces.Query;

public interface IUserQuery
{
    public Task<List<User>> GetUsers();
    public Task<User> GetById(int id);
}
