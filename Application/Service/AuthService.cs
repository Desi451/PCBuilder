using Application.DTO.UserDTOs;
using Application.Interfaces;
using Application.Service.Common;
using AutoMapper;
using Domain.Common;
using Domain.Entities;
using Domain.Interfaces.Repository;
using Microsoft.AspNetCore.Identity;

namespace Application.Service;

public class AuthService : IAuthService
{
    private const string InvalidCredentialsMessage = "Invalid login or password.";

    private readonly IUserRepository _repository;
    private readonly IMapper _mapper;
    private readonly SignInManager<User> _signInManager;

    public AuthService(IMapper mapper,
        IUserRepository repository, SignInManager<User> signInManager)
    {
        _repository = repository;
        _mapper = mapper;
        _signInManager = signInManager;
    }

    public async Task<UserInfoDTO> Login(LoginUserDTO login)
    {
        var user = await _repository.FindByLoginOrEmail(login.Login.Trim());
        if (user is null)
        {
            throw new UnauthorizedException(InvalidCredentialsMessage);
        }

        var result = await _signInManager.CheckPasswordSignInAsync(user, login.Password, lockoutOnFailure: false);
        if (!result.Succeeded)
        {
            throw new UnauthorizedException(InvalidCredentialsMessage);
        }

        await _signInManager.SignInAsync(user, isPersistent: true);
        return await CreateUserInfo(user);
    }

    public async Task Register(AddUserDTO user)
    {
        await _repository.Create(_mapper.Map<User>(user), user.Password);
    }

    public async Task Logout()
    {
        await _signInManager.SignOutAsync();
    }

    public async Task<UserInfoDTO> GetCurrentUser(int userId)
    {
        try
        {
            var user = await _repository.GetById(userId);
            return await CreateUserInfo(user);
        }
        catch (NotFoundException)
        {
            throw new UnauthorizedException("The signed-in user no longer exists.");
        }
    }

    public async Task<UserInfoDTO> Edit(EditProfileDTO profile, int userId)
    {
        await _repository.UpdateProfile(userId, profile.Login, profile.Email, profile.CurrentPassword, profile.NewPassword);

        var user = await _repository.GetById(userId);
        await _signInManager.RefreshSignInAsync(user);
        return await CreateUserInfo(user);
    }

    private async Task<UserInfoDTO> CreateUserInfo(User user)
    {
        var role = await _repository.GetRole(user) ?? Roles.User;

        return new UserInfoDTO
        {
            Id = user.Id,
            Login = user.UserName!,
            Email = user.Email!,
            Role = role,
            UserRank = GetLegacyRank(role)
        };
    }

    // Temporary numeric rank kept for the existing UI checks.
    private static int GetLegacyRank(string role)
    {
        return role switch
        {
            Roles.HeadAdmin => 5,
            Roles.Admin => 2,
            _ => 1
        };
    }
}
