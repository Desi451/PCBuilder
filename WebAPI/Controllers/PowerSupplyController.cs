using Application.DTO.BrandDTOs;
using Application.DTO.Components.PowerSupllyDTOs;
using Application.Interfaces;
using Application.Interfaces.Components;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PowerSupplyController : ControllerBase
{
    private readonly IPowerSupplyService _service;
    public PowerSupplyController(IPowerSupplyService service)
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
    public async Task<IActionResult> Create(AddPowerSupplyDTO psu)
    {
        await _service.Add(psu);
        return Ok();
    }

    [HttpPut("update")]
    public async Task<IActionResult> Update(PowerSupplyDTO psu)
    {
        await _service.Update(psu);
        return Ok();
    }

    [HttpDelete("delete")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.Delete(id);
        return NoContent();
    }
}
