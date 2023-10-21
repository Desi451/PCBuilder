using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IUserService _service;


    public AuthController(IUserService service)
    {
        _service = service;
    }

    [HttpPost("checkmail")]
    public async Task<IActionResult> ConfirmMail(int id)
    {
        await _service.CheckMail(id);
        return Ok();
    }
}
