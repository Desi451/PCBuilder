using Application.DTO.UserDTOs;

namespace Application.Interfaces;

public interface IUserService
{
    public List<UserDTO> GetAll();
    public UserDTO GetById(int id);
    public UserDTO Add(ManageUserDTO post);
    public void Update(ManageUserDTO updatePost);
    public void Delete(int id);
}
