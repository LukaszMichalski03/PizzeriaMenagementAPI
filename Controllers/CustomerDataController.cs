using Microsoft.AspNetCore.Mvc;
using PizzeriaManagementAPI.Interfaces;
using PizzeriaManagementAPI.Models;
using PizzeriaManagementAPI.Services;

namespace PizzeriaManagementAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerDataController : ControllerBase
    {
        private readonly ICustomerDataService _customerDataService;

        public CustomerDataController(ICustomerDataService customerDataService)
        {
            _customerDataService = customerDataService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerDataDto>>> GetAll()
        {
            List<CustomerDataDto> sizesDto = await _customerDataService.GetAllAsync();

            return Ok(sizesDto);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<CustomerDataDto>>> Get([FromRoute] int id)
        {
            var sizeDto = await _customerDataService.GetByIdAsync(id);

            return Ok(sizeDto);
        }
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] EditCustomerDataDto dto)
        {
            int createId = await _customerDataService.CreateAsync(dto);
            return Created($"size/{createId}", null);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            await _customerDataService.DeleteAsync(id);
            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Update([FromRoute] int id, [FromBody] EditCustomerDataDto dto)
        {
            await _customerDataService.UpdateAsync(id, dto);
            return Ok();

        }
    }
}
