using Domain.Entities;

namespace Domain.Interfaces.Repository;

public interface IUserRepository
{
    Task Add(User user);
    Task Update(User user);
    Task Delete(int id);
    Task ChangeMailStatus(int id);

    //query
    Task<List<User>> GetUsers();
    Task<bool> GetByLoginMail(User log);
    Task<User> GetById(int id);
}
