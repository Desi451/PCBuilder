using System.Security.Claims;
using Application.DTO.UserDTOs;
using Application.Interfaces;
using Application.Service.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _service;

    public AuthController(IAuthService service)
    {
        _service = service;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginUserDTO login)
    {
        var res = await _service.Login(login);
        return Ok(res);
    }

    [Authorize]
    [HttpGet("getUserInfo")]
    public async Task<IActionResult> GetUserInfo()
    {
        var res = await _service.GetCurrentUser(GetCurrentUserId());
        return Ok(res);
    }

    [Authorize]
    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        await _service.Logout();
        return Ok("Logged out successfully");
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(AddUserDTO user)
    {
        await _service.Register(user);
        return Ok();
    }

    [Authorize]
    [HttpPatch("edit")]
    public async Task<IActionResult> Edit(EditProfileDTO user)
    {
        var res = await _service.Edit(user, GetCurrentUserId());
        return Ok(res);
    }

    private int GetCurrentUserId()
    {
        var value = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (!int.TryParse(value, out var userId))
        {
            throw new UnauthorizedException("Invalid user identity.");
        }

        return userId;
    }
}
