using Domain.Entities;
using Domain.Interfaces.Query;
using Infrastructure.Context;

namespace Infrastructure.Queries;

public class UserQuery : IUserQuery
{
    private AppDbContext _context;

    public UserQuery(AppDbContext context)
    {
        _context = context;
    }

    public User GetById(int id)
    {
        return _context.Users.FirstOrDefault(x => x.Id == id);
    }

    public List<User> GetUsers()
    {
        return _context.Users.ToList();
    }
}
