using Application.DTO.Computer;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ComputerController : ControllerBase
{
    private readonly IComputerService _service;

    public ComputerController(IComputerService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var res = await _service.GetComputers();
        return Ok(res);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var res = await _service.GetById(id);
        return Ok(res);
    }

    [HttpGet("views")]
    public async Task<IActionResult> GetViews()
    {
        var res = await _service.GetComputersView();
        return Ok(res);
    }

    [HttpGet("views/{id}")]
    public async Task<IActionResult> GetViewsByUser(int id)
    {
        var res = await _service.GetComputersViewByUser(id);
        return Ok(res);
    }

    [HttpGet("fulldata/{id}")]
    public async Task<IActionResult> GetFullData(int id)
    {
        var res = await _service.GetFullDataById(id);
        return Ok(res);
    }

    [HttpPost("add")]
    public async Task<IActionResult> Create(AddComputerDTO pc)
    {
        await _service.Add(pc);
        return Ok();
    }

    [HttpPut("update")]
    public async Task<IActionResult> Update(ComputerDTO pc)
    {
        await _service.Update(pc);
        return Ok();
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.Delete(id);
        return NoContent();
    }

    // computer configuration

    [HttpGet("cpubrands")]
    public async Task<IActionResult> GetCpuBrands()
    {
        var res = await _service.GetCpuBrands();
        return Ok(res);
    }

    [HttpGet("cpus/{id}")]
    public async Task<IActionResult> GetCpusForBrand(int id)
    {
        return Ok(await _service.GetCPUsByBrandId(id));
    }

    [HttpGet("motherboards/{id}")]
    public async Task<IActionResult> GetMotherboardsForSocket(int id)
    {
        return Ok(await _service.GetMotherBoardsBySocket(id));
    }

    [HttpGet("rams/{id}")]
    public async Task<IActionResult> GetRamsForMotherboard(int id)
    {
        return Ok(await _service.GetRamsByMotherboard(id));
    }

    [HttpGet("psus/{id}")]
    public async Task<IActionResult> GetPsusByWattage(int id)
    {
        return Ok(await _service.GetPsuByWattage(id));
    }

    [HttpPost("cases")]
    public async Task<IActionResult> GetCasesBySize(CaseRequest req)
    {
        var res = await _service.GetCasesByStandard(req.CaseId, req.GpuLenght);
        return Ok(res);
    }
}
