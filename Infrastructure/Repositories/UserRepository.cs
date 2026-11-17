using Application.Service.Common;
using Domain.Common;
using Domain.Entities;
using Domain.Interfaces.Repository;
using Infrastructure.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private const string DuplicateUserNameCode = "DuplicateUserName";
    private const string DuplicateEmailCode = "DuplicateEmail";

    private readonly AppDbContext _context;
    private readonly UserManager<User> _userManager;

    public UserRepository(AppDbContext context, UserManager<User> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    public async Task<User> Create(User user, string password)
    {
        await using var transaction = await _context.Database.BeginTransactionAsync();
        ThrowIfFailed(await _userManager.CreateAsync(user, password));
        ThrowIfFailed(await _userManager.AddToRoleAsync(user, Roles.User));
        await transaction.CommitAsync();

        return user;
    }

    public async Task UpdateProfile(int id, string login, string email, string? currentPassword, string? newPassword)
    {
        var user = await GetById(id);

        await using var transaction = await _context.Database.BeginTransactionAsync();

        user.UserName = login;
        user.Email = email;
        ThrowIfFailed(await _userManager.UpdateAsync(user));

        if (!string.IsNullOrEmpty(newPassword))
        {
            if (string.IsNullOrEmpty(currentPassword))
            {
                throw new AppException("Current password is required to change the password.");
            }

            ThrowIfFailed(await _userManager.ChangePasswordAsync(user, currentPassword, newPassword));
        }

        await transaction.CommitAsync();
    }

    public async Task Delete(int id)
    {
        var user = await GetById(id);
        var roles = await _userManager.GetRolesAsync(user);

        if (roles.Contains(Roles.HeadAdmin))
        {
            throw new AppException("Cannot Delete An HeadAdmin");
        }

        user.IsDeleted = true;
        user.SecurityStamp = Guid.NewGuid().ToString();
    }

    #region query
    public async Task<User> GetById(int id)
    {
        var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == id);
        if (user == null)
        {
            throw new NotFoundException($"No user with ID = {id}");
        }

        return user;
    }

    public async Task<User?> FindByLoginOrEmail(string loginOrEmail)
    {
        if (loginOrEmail.Contains('@'))
        {
            return await _userManager.FindByEmailAsync(loginOrEmail);
        }

        return await _userManager.FindByNameAsync(loginOrEmail);
    }

    public async Task<string?> GetRole(User user)
    {
        var roles = await _userManager.GetRolesAsync(user);
        return roles.FirstOrDefault();
    }

    public async Task<List<User>> GetUsers()
    {
        return await _userManager.Users.ToListAsync();
    }
    #endregion

    private static void ThrowIfFailed(IdentityResult result)
    {
        if (result.Succeeded)
        {
            return;
        }

        var message = string.Join(" ", result.Errors.Select(x => x.Description));
        var isDuplicate = result.Errors.Any(x => x.Code == DuplicateUserNameCode || x.Code == DuplicateEmailCode);

        if (isDuplicate)
        {
            throw new ConflictException(message);
        }

        throw new AppException(message);
    }
}
