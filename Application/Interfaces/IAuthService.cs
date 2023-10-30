using Application.DTO.UserDTOs;
using Domain.Entities;

namespace Application.Interfaces;

public interface IAuthService
{
    Task<bool> Login(LoginUserDTO user);
    Task Register(AddUserDTO user);
    Task GetCurrentUser();
    Task ChangeMailStatus(int id);
}
