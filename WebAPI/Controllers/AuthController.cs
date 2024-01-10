using Application.DTO.UserDTOs;
using Application.Interfaces;
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

    //[HttpPost("confirmemail")]
    //public async Task<IActionResult> ConfirmMail(int id)
    //{
    //    await _service.ChangeMailStatus(id);
    //    return Ok();
    //}


    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginUserDTO login)
    {
        var res = await _service.Login(login);
        if (res is not null)
        {
           HttpContext.Session.SetInt32("UserId", res.Id);
           HttpContext.Session.SetString("Username", res.Login);
           HttpContext.Session.SetInt32("UserRank", res.RankId);

            return Ok(res);
        }
        else
            return BadRequest();
    }

    [HttpGet("getUserInfo")]
    public IActionResult GetUserInfo()
    {
        var userId = HttpContext.Session.GetInt32("UserId");
        var username = HttpContext.Session.GetString("Username");
        var userRank = HttpContext.Session.GetInt32("UserRank");

        return Ok(new { userId, username, userRank });
    }

    [HttpPost("logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Remove("UserId");
        HttpContext.Session.Remove("Username");
        HttpContext.Session.Remove("UserRank");
        Response.Cookies.Delete(".AspNetCore.Session");
        return Ok("Logged out successfully");
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(AddUserDTO user)
    {
        await _service.Register(user);
        return Ok();
    }

    [HttpPatch("edit/{id}")]
    public async Task<IActionResult> Edit(AddUserDTO user, int id)
    {
        await _service.Edit(user,id);
        return Ok();
    }
}
