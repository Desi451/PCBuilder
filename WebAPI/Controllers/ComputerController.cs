using Application.DTO.Computer;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
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

    [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var res = await _service.GetComputers();
        return Ok(res);
    }

    [AllowAnonymous]
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var res = await _service.GetById(id);
        return Ok(res);
    }

    [AllowAnonymous]
    [HttpGet("views")]
    public async Task<IActionResult> GetViews()
    {
        var res = await _service.GetComputersView();
        return Ok(res);
    }

    [AllowAnonymous]
    [HttpGet("views/{id}")]
    public async Task<IActionResult> GetViewsByUser(int id)
    {
        var res = await _service.GetComputersViewByUser(id);
        return Ok(res);
    }

    [AllowAnonymous]
    [HttpGet("fulldata/{id}")]
    public async Task<IActionResult> GetFullData(int id)
    {
        var res = await _service.GetFullDataById(id);
        return Ok(res);
    }

    [Authorize]
    [HttpPost("add")]
    public async Task<IActionResult> Create(AddComputerDTO pc)
    {
        await _service.Add(pc);
        return Ok();
    }

    [Authorize]
    [HttpPost("validate")]
    public async Task<IActionResult> Validate(AddComputerDTO pc)
    {
        return Ok(await _service.Validate(pc));
    }

    [Authorize]
    [HttpPut("update")]
    public async Task<IActionResult> Update(ComputerDTO pc)
    {
        await _service.Update(pc);
        return Ok();
    }

    [Authorize]
    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.Delete(id);
        return NoContent();
    }

    // computer configuration

    [AllowAnonymous]
    [HttpGet("cpubrands")]
    public async Task<IActionResult> GetCpuBrands()
    {
        var res = await _service.GetCpuBrands();
        return Ok(res);
    }

    [AllowAnonymous]
    [HttpGet("cpus/{id}")]
    public async Task<IActionResult> GetCpusForBrand(int id)
    {
        return Ok(await _service.GetCPUsByBrandId(id));
    }

    [AllowAnonymous]
    [HttpGet("motherboards/{id}")]
    public async Task<IActionResult> GetMotherboardsForSocket(int id)
    {
        return Ok(await _service.GetMotherBoardsBySocket(id));
    }

    [AllowAnonymous]
    [HttpGet("rams/{id}")]
    public async Task<IActionResult> GetRamsForMotherboard(int id)
    {
        return Ok(await _service.GetRamsByMotherboard(id));
    }

    [AllowAnonymous]
    [HttpGet("psus/{cpuId}")]
    public async Task<IActionResult> GetPsusForBuild(int cpuId, [FromQuery] int? gpuId)
    {
        return Ok(await _service.GetPsusForBuild(cpuId, gpuId));
    }

    [AllowAnonymous]
    [HttpPost("cases")]
    public async Task<IActionResult> GetCasesForBuild(CaseRequest req)
    {
        var res = await _service.GetCasesForBuild(req);
        return Ok(res);
    }
}
