using Microsoft.AspNetCore.Mvc;
using PizzeriaManagementAPI.Entities;
using PizzeriaManagementAPI.Interfaces;
using PizzeriaManagementAPI.Models;

namespace PizzeriaManagementAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DishController : ControllerBase
    {
        private readonly IDishService _dishService;

        public DishController(IDishService dishService)
        {
            this._dishService = dishService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dish>>> GetAll()
        {
            var dishes = await _dishService.GetAllAsync();
            return Ok(dishes);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Dish>> Get([FromRoute]int id)
        {
            DishDto dish = await _dishService.GetByIdAsync(id);
            
            return Ok(dish);
        }
        [HttpPost]
        public async Task<ActionResult> Create([FromBody]EditDishDto dto)
        {
            int result = await _dishService.CreateAsync(dto);
            return Created($"/api/Dish/{result}", null);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute]int id)
        {
            await _dishService.DeleteAsync(id);
            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Update([FromRoute]int id, [FromBody]EditDishDto dto)
        {
            await _dishService.UpdateAsync(id, dto);

            return Ok();
        }
    }
}
