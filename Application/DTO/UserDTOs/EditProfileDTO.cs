namespace Application.DTO.UserDTOs;

public class EditProfileDTO
{
    public string Login { get; set; }
    public string Email { get; set; }
    public string? CurrentPassword { get; set; }
    public string? NewPassword { get; set; }
}
