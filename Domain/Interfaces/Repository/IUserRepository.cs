using Domain.Entities;

namespace Domain.Interfaces.Repository;

public interface IUserRepository
{
    Task<User> Create(User user, string password);
    Task UpdateProfile(int id, string login, string email, string? currentPassword, string? newPassword);
    Task Delete(int id);

    //query
    Task<List<User>> GetUsers();
    Task<User> GetById(int id);
    Task<User?> FindByLoginOrEmail(string loginOrEmail);
    Task<string?> GetRole(User user);
}
