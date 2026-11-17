using Application.DTO.BrandDTOs;
using Application.DTO.Components.Motherboard;
using Application.Interfaces;
using Application.Interfaces.Components;
using Domain.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Authorize(Policy = Policies.AdminOrAbove)]
[Route("api/[controller]")]
[ApiController]
public class MotherboardController : ControllerBase
{
    private readonly IMotherBoardService _service;
    public MotherboardController(IMotherBoardService service)
    {
        _service = service;
    }

    [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var brands = await _service.GetMotherboards();
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
    public async Task<IActionResult> Create(AddMotherboardDTO mobo)
    {
        await _service.Add(mobo);
        return Ok();
    }

    [HttpPut("update")]
    public async Task<IActionResult> Update(UpdateMotherboardDTO mobo)
    {
        await _service.Update(mobo);
        return Ok();
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.Delete(id);
        return NoContent();
    }
}
