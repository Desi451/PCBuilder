using Application.DTO.UserDTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _service;
    public static UserDTO user = new UserDTO();

    public AuthController(IAuthService service)
    {
        _service = service;
    }

    [HttpPost("confirmemail")]
    public async Task<IActionResult> ConfirmMail(int id)
    {
        await _service.ChangeMailStatus(id);
        return Ok();
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginUserDTO login)
    {
        var res = await _service.Login(login);
        if(res == true)
            return Ok(res);
        else
            return BadRequest();
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(AddUserDTO user)
    {
        await _service.Register(user);
        return Ok();
    }
}
