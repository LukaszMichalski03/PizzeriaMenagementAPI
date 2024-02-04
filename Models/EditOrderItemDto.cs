using PizzeriaManagementAPI.Entities;

namespace PizzeriaManagementAPI.Models
{
    public class EditOrderItemDto
    {
        
        public int DishId { get; set; }
        public DishDto Dish { get; set; }
        public int SizeId { get; set; }
        public SizeDto Size { get; set; }
    }
}
