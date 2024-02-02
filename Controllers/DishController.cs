using Microsoft.AspNetCore.Mvc;
using PizzeriaManagementAPI.Entities;
using PizzeriaManagementAPI.Interfaces;

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
        public ActionResult<IEnumerable<Dish>> GetAll()
        {
            return Ok();
        }
    }
}
