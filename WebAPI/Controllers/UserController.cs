using Domain.Interfaces.Query;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserQuery _query;

    public UserController(IUserQuery query)
    {
        _query = query;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var users = _query.GetUsers();
        return Ok(users);
    }
}

