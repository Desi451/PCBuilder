using Application.DTO.UserDTOs;
using Application.Service.Common;
using Domain.Entities;
using Domain.Interfaces.Repository;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Web.Http;

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
        Rank r = await _context.Ranks.FirstOrDefaultAsync(x => x.Id == 2); // 2 => normal user
        try
        {
            user.IsDeleted = false;
            user.IsEmailConfirmed = false;
            user.CreatedBy = user.Id;
            user.Rank = r;
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

    public async Task Update(User user)
    {
        var res = await _context.Users.FirstOrDefaultAsync(x => x.Id == user.Id);
        if(res != null)
        {
            res.Login = user.Login;
            res.Email = user.Email;
            res.Password = user.Password;
        }
        else
        {
            var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
            {
                Content = new StringContent(string.Format("No user with ID = {0}", user.Id)),
                ReasonPhrase = "Product ID Not Found"
            };
            throw new HttpResponseException(resp);
        }
    }

    public async Task ChangeMailStatus(int id)
    {
        var res = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
        if(res != null)
        {
            res.IsEmailConfirmed = true;
        }
    }

    #region query
    public async Task<User> GetById(int id)
    {
        var res = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
        if(res != null)
        {
            return res;
        }
        else
        {
            var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
            {
                Content = new StringContent(string.Format("No user with ID = {0}", id)),
                ReasonPhrase = "Product ID Not Found"
            };
            throw new HttpResponseException(resp);
        }
    }

    public async Task<bool> GetByLoginMail(User log)
    {
        var res = await _context.Users.FirstOrDefaultAsync(x => x.Login == log.Login || x.Email == log.Email);

        if (res.Password == log.Password && res.IsDeleted == false)
            return true;
        else
            return false;
    }

    public async Task<List<User>> GetUsers()
    {
        return await _context.Users.ToListAsync();
    }
    #endregion
}
