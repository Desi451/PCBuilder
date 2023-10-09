using Domain.Entities;
using Domain.Interfaces.Repository;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task Add(User user)
    {
        try
        {
            user.IsDeleted = false;
            user.IsEmailConfirmed = false;
            user.CreatedBy = user.Login;
            _context.Add(user);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public async Task Delete(int id)
    {
        User res = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
        res.IsDeleted = true;
    }

    public async Task Update(User user)
    {
        var res = await _context.Users.FirstOrDefaultAsync(x => x.Id == user.Id);
        res.Login = user.Login;
        res.Email = user.Email;
        res.Password = user.Password;
    }

    public async Task ConfirmMail(int id)
    {
        User res = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
        res.IsEmailConfirmed = true;
    }

    #region query
    public async Task<User> GetById(int id)
    {
        try
        {
            var res = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            return res;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public async Task<List<User>> GetUsers()
    {
        return await _context.Users.ToListAsync();
    }
    #endregion
}
