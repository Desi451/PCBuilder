namespace Application.DTO.UserDTOs;

//for query and edit
public class UserDTO
{
    public int Id { get; set; }
    public string Login { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}
