using Domain.Entities;

namespace Domain.Interfaces.Query;

public interface IUserQuery
{
    public List<User> GetUsers();
    public User GetById(int id);
}
