using System.Net;
using Application.Service.Common;
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
        Rank r = await _context.Ranks.FirstOrDefaultAsync(x => x.Id == 1); // 2 => normal user
        try
        {
            user.IsDeleted = false;
            //user.IsEmailConfirmed = false;
            user.Rank = r;
            user.RankId = r.Id;
            user.Password = HashPassword(user.Password);
            await _context.AddAsync(user);
        }
        catch
        {
            throw;
        }
    }

    public async Task Delete(int id)
    {
        User res = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
        if (res.RankId == 5)
            throw new AppException("Cannot Delete An HeadAdmin");
        else if (res.IsDeleted == true)
            throw new AppException("User has already the deleted status");
        else
            res.IsDeleted = true;
    }

    public async Task Update(User user, int id)
    {
        var res = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
        if (res != null)
        {
            res.Login = user.Login;
            res.Email = user.Email;
            res.Password = HashPassword(user.Password);
        }
        else
        {
            var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
            {
                Content = new StringContent(string.Format("No user with ID = {0}", user.Id)),
                ReasonPhrase = "Product ID Not Found"
            };
            throw new Exception();
        }
    }

    //public async Task ChangeMailStatus(int id)
    //{
    //    var res = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
    //    if(res != null)
    //    {
    //        res.IsEmailConfirmed = true;
    //    }
    //}

    #region query
    public async Task<User> GetById(int id)
    {
        var res = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
        if (res != null)
        {
            res.Password = "";
            return res;
        }
        else
        {
            var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
            {
                Content = new StringContent(string.Format("No user with ID = {0}", id)),
                ReasonPhrase = "Product ID Not Found"
            };
            throw new Exception();
        }
    }

    public async Task<User> GetByLoginMail(User log)
    {
        var res = await _context.Users.FirstOrDefaultAsync(x => x.Login == log.Login || x.Email == log.Email);

        if (res != null && VerifyPassword(res.Password, log.Password) && res.IsDeleted == false)
            return res;
        else
            throw new Exception();
    }

    public async Task<List<User>> GetUsers()
    {
        return await _context.Users.ToListAsync();
    }
    #endregion

    private static string HashPassword(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }

    private static bool VerifyPassword(string hashedPassword, string providedPassword)
    {
        return BCrypt.Net.BCrypt.Verify(providedPassword, hashedPassword);
    }
}
