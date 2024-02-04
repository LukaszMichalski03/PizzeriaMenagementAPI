using PizzeriaManagementAPI.Entities;

namespace PizzeriaManagementAPI.Models
{
    public class OrderItemDto
    {
        public int Id { get; set; }
        public int DishId { get; set; }
        public DishDto Dish { get; set; }
        public int SizeId { get; set; }
        public SizeDto Size { get; set; }
        
    }
}
