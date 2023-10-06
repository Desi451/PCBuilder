using Domain.Entities;
using Domain.Interfaces.Query;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Queries;

public class UserQuery : IUserQuery
{
    private readonly AppDbContext _context;

    public UserQuery(AppDbContext context)
    {
        _context = context;
    }

    public async Task<User> GetById(int id)
    {
        try
        {
            var res = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            return res;
        }
        catch(Exception ex)
        {
            throw ex;
        }
    }

    public async Task<List<User>> GetUsers()
    {
        return await _context.Users.ToListAsync();
    }
}
