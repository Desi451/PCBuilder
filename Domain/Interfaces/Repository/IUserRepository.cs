using Domain.Entities;

namespace Domain.Interfaces.Repository;

public interface IUserRepository
{
    Task Add(User user);
    Task Update(User user, int id);
    Task Delete(int id);
    //Task ChangeMailStatus(int id);

    //query
    Task<List<User>> GetUsers();
    Task<User> GetByLoginMail(User log);
    Task<User> GetById(int id);
}
