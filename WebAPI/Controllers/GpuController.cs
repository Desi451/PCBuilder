using Application.DTO.Components.CPU;
using Application.DTO.Components.GPU;
using Application.Interfaces.Components;
using Domain.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers;

[Authorize(Policy = Policies.AdminOrAbove)]
[Route("api/[controller]")]
[ApiController]
public class GpuController : ControllerBase
{
    private IGpuService _service;

    public GpuController(IGpuService service) 
    { 
        _service = service;
    }

    [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var gpus = await _service.GetAll();
        return Ok(gpus);
    }

    [AllowAnonymous]
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var res = await _service.GetById(id);
        return Ok(res);
    }

    [HttpPost("add")]
    public async Task<IActionResult> Create(AddGpuDTO gpu)
    {
        await _service.Add(gpu);
        return Ok();
    }

    [HttpPut("update")]
    public async Task<IActionResult> Update(GpuDTO gpu)
    {
        await _service.Update(gpu);
        return Ok();
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.Delete(id);
        return NoContent();
    }
}

