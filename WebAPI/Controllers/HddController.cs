using Application.DTO.Components.Drive;
using Application.Interfaces.Components;
using Domain.Common;
using Domain.Entities.Components.Drives;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Authorize(Policy = Policies.AdminOrAbove)]
[Route("api/[controller]")]
[ApiController]
public class HddController : ControllerBase
{
    private readonly IHddService _service;
    public HddController(IHddService service)
    {
        _service = service;
    }

    [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var res = await _service.GetAll();
        return Ok(res);
    }

    [AllowAnonymous]
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var res = await _service.GetById(id);
        return Ok(res);
    }

    [HttpPost("add")]
    public async Task<IActionResult> Create(AddHddDTO hdd)
    {
        await _service.Add(hdd);
        return Ok();
    }

    [HttpPut("update")]
    public async Task<IActionResult> Update(HddDTO hdd)
    {
        await _service.Update(hdd);
        return Ok();
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.Delete(id);
        return NoContent();
    }
}
