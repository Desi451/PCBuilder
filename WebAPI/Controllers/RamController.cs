using Application.DTO.Components.Case;
using Application.DTO.Components.Case_Size;
using Application.DTO.Components.RAM;
using Application.Interfaces.Components;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RamController : ControllerBase
    {
        private readonly IRAMService _service;

        public RamController(IRAMService service)
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
        public async Task<IActionResult> Create(AddRamDTO box)
        {
            await _service.Add(box);
            return Ok();
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(RamDTO box)
        {
            await _service.Update(box);
            return Ok();
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.Delete(id);
            return NoContent();
        }

        [HttpGet("speed")]
        public async Task<IActionResult> GetAllSpeeds()
        {
            var brands = await _service.GetAllSpeed();
            return Ok(brands);
        }

        [HttpGet("speed/{id}")]
        public async Task<IActionResult> GetSpeed(int id)
        {
            var res = await _service.GetSpeedById(id);
            return Ok(res);
        }

        [HttpPost("addspeed")]
        public async Task<IActionResult> CreateSpeed(AddRamSpeedDTO box)
        {
            await _service.AddSpeed(box);
            return Ok();
        }

        [HttpPut("updatespeed")]
        public async Task<IActionResult> UpdateSpeed(RamSpeedDTO box)
        {
            await _service.UpdateSpeed(box);
            return Ok();
        }

        [HttpDelete("deletespeed")]
        public async Task<IActionResult> DeleteSpeed(int id)
        {
            await _service.DeleteSpeed(id);
            return NoContent();
        }
    }
}
