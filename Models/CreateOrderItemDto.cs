using PizzeriaManagementAPI.Entities;

namespace PizzeriaManagementAPI.Models
{
    public class CreateOrderItemDto
    {
        public int Id { get; set; }
        public int DishId { get; set; }
        public double DishPrice { get; set; }
        public int SizeId { get; set; }
        public double PriceModifier { get; set; }
        
    }
}
