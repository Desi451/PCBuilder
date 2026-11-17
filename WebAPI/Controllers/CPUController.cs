using Application.DTO.Components.CPU;
using Application.Interfaces.Components;
using Domain.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Authorize(Policy = Policies.AdminOrAbove)]
[Route("api/[controller]")]
[ApiController]
public class CPUController : ControllerBase
{
    private readonly ICPUService _service;

    public CPUController(ICPUService service)
    {
        _service = service;
    }

    [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var brands = await _service.GetAll();
        return Ok(brands);
    }

    [AllowAnonymous]
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var res = await _service.GetById(id);
        return Ok(res);
    }

    [HttpPost("add")]
    public async Task<IActionResult> Create(AddCpuDTO cpu)
    {
        await _service.Add(cpu);
        return Ok();
    }

    [HttpPut("update")]
    public async Task<IActionResult> Update(CpuDTO cpu)
    {
        await _service.Update(cpu);
        return Ok();
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.Delete(id);
        return NoContent();
    }

    [AllowAnonymous]
    [HttpGet("sockets")]
    public async Task<IActionResult> GetAllSockets()
    {
        var brands = await _service.GetAllSockets();
        return Ok(brands);
    }

    [AllowAnonymous]
    [HttpGet("socketsbrand/{id}")]
    public async Task<IActionResult> GetAllSocketsByBrand(int id)
    {
        var brands = await _service.GetSocketsByBrandId(id);
        return Ok(brands);
    }

    [AllowAnonymous]
    [HttpGet("sockets/{id}")]
    public async Task<IActionResult> GetSocket(int id)
    {
        var res = await _service.GetSocketById(id);
        return Ok(res);
    }

    [HttpPost("addsocket")]
    public async Task<IActionResult> CreateSocket(AddSocketCpuDTO cpu)
    {
        await _service.AddSocket(cpu);
        return Ok();
    }

    [HttpPut("updatesocket")]
    public async Task<IActionResult> UpdateSocket(SocketCpuDTO cpu)
    {
        await _service.UpdateSocket(cpu);
        return Ok();
    }

    [HttpDelete("deletesocket/{id}")]
    public async Task<IActionResult> DeleteSocket(int id)
    {
        await _service.DeleteSocket(id);
        return NoContent();
    }
}
