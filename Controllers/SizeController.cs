
using Microsoft.AspNetCore.Mvc;
using PizzeriaManagementAPI.Entities;
using PizzeriaManagementAPI.Interfaces;
using PizzeriaManagementAPI.Models;

namespace PizzeriaManagementAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SizeController : ControllerBase
    {
        private readonly ISizeService _sizeService;

        public SizeController(ISizeService sizeService)
        {
            _sizeService = sizeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SizeDto>>> GetAll()
        {
            IEnumerable<SizeDto> sizesDto = await _sizeService.GetAllAsync();

            return Ok(sizesDto);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<SizeDto>>> Get([FromRoute]int id)
        {
            var sizeDto = await _sizeService.GetByIdAsync(id);

            return Ok(sizeDto);
        }
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] EditSizeDto dto)
        {
            int createId = await _sizeService.CreateAsync(dto);
            return Created($"size/{createId}", null);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute]int id)
        {
            await _sizeService.DeleteAsync(id);
            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Update([FromRoute]int id, [FromBody] EditSizeDto dto)
        {
            await _sizeService.UpdateAsync(id, dto);
            return Ok();

        }
    }
}
