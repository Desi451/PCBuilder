using Application.DTO.BrandDTOs;
using Application.DTO.SeriesDTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SeriesController : ControllerBase
{
    private readonly ISeriesService _service;
    public SeriesController(ISeriesService service)
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

    [HttpGet("brandId/{id}")]
    public async Task<IActionResult> GetByBrand(int id)
    {
        var res = await _service.GetByBrandId(id);
        return Ok(res);
    }

    [HttpPost("add")]
    public async Task<IActionResult> Create(AddSeriesDTO series)
    {
        await _service.Add(series);
        return Ok();
    }

    [HttpPut("update")]
    public async Task<IActionResult> Update(SeriesDTO series)
    {
        await _service.Update(series);
        return Ok();
    }

    [HttpDelete("delete")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.Delete(id);
        return NoContent();
    }
}
