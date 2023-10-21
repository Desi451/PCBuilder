using Application.DTO.UserDTOs;

namespace Application.Interfaces;

public interface IUserService
{
    public Task<List<UserDTO>> GetAll();
    public Task<UserDTO> GetById(int id);
    public Task<UserDTO> Add(AddUserDTO post);
    public Task Update(UserDTO updateUser);
    public Task Delete(int id);
    public Task CheckMail(int id);
    public Task Login(LoginUserDTO user);
    public Task Register(AddUserDTO user);
}
