using Application.DTO.BrandDTOs;
using Application.DTO.Components.Drive;
using Application.Interfaces;
using Application.Interfaces.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SsdController : ControllerBase
{
    private readonly ISsdService _service;
    public SsdController(ISsdService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var brands = await _service.GetAll();
        return Ok(brands);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var res = await _service.GetById(id);
        return Ok(res);
    }

    [HttpPost("add")]
    public async Task<IActionResult> Create(AddSsdDTO ssd)
    {
        await _service.Add(ssd);
        return Ok();
    }

    [HttpPut("update")]
    public async Task<IActionResult> Update(SsdDTO ssd)
    {
        await _service.Update(ssd);
        return Ok();
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.Delete(id);
        return NoContent();
    }
}
