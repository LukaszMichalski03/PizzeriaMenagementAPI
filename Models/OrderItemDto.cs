namespace PizzeriaManagementAPI.Models
{
    public class OrderItemDto
    {
        public int DishId { get; set; }
        public DishDto DishDto { get; set; }
        public int SizeId { get; set; }
        public SizeDto SizeDto { get; set; }
    }
}
