using Application.DTO.UserDTOs;

namespace Application.Interfaces;

public interface IAuthService
{
    Task<UserInfoDTO> Login(LoginUserDTO user);
    Task Register(AddUserDTO user);
    Task Logout();
    Task<UserInfoDTO> GetCurrentUser(int userId);
    Task<UserInfoDTO> Edit(EditProfileDTO user, int userId);
}
