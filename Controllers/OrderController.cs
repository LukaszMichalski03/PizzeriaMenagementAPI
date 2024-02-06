using Microsoft.AspNetCore.Mvc;
using PizzeriaManagementAPI.Interfaces;
using PizzeriaManagementAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace PizzeriaManagementAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var orders = await _orderService.GetAllAsync();
            return Ok(orders);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> Get([FromRoute] int id)
        {
            var order = await _orderService.GetByIdAsync(id);
            return Ok(order);
        }
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateOrderDto dto)
        {
            int id = await _orderService.CreateAsync(dto);
            return Created($"order/{id}", null);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute]int id)
        {
            await _orderService.DeleteAsync(id);
            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Update([FromRoute]int id, [FromBody] CreateOrderDto dto)
        {
            await _orderService.UpdateAsync(id, dto);
            return Ok();
        }
    }
}
