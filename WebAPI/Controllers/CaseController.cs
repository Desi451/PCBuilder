using Application.DTO.Components.Case;
using Application.DTO.Components.Case_Size;
using Application.Interfaces.Components;
using Domain.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Authorize(Policy = Policies.AdminOrAbove)]
[Route("api/[controller]")]
[ApiController]
public class CaseController : ControllerBase
{
    private readonly ICaseService _service;

    public CaseController(ICaseService service)
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
    public async Task<IActionResult> Create(AddCaseDTO box)
    {
        await _service.Add(box);
        return Ok();
    }

    [HttpPut("update")]
    public async Task<IActionResult> Update(CaseDTO box)
    {
        await _service.Update(box);
        return Ok();
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.Delete(id);
        return NoContent();
    }
}
