using PizzeriaManagementAPI.Entities;

namespace PizzeriaManagementAPI.Models
{
    public class OrderDto
    {
        public int Id { get; set; }
        public double TotalPrice { get; set; }
        public List<OrderItemDto> OrderItemsDto { get; set; }
        public CustomerDataDto? CustomerDataDto { get; set; }
    }
}
