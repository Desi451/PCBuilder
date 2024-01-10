using Application.DTO.UserDTOs;
using Domain.Entities;

namespace Application.Interfaces;

public interface IAuthService
{
    Task<UserDTO> Login(LoginUserDTO user);
    Task Register(AddUserDTO user);
    Task Edit(AddUserDTO user, int id);
    Task GetCurrentUser();
    //Task ChangeMailStatus(int id);
}
