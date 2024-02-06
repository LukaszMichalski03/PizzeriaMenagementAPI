using PizzeriaManagementAPI.Entities;

namespace PizzeriaManagementAPI.Models
{
    public class CreateOrderDto
    {
        public double? TotalPrice { get; set; }
        public ICollection<CreateOrderItemDto> OrderItems { get; set; }
        public CustomerDataDto? CustomerData { get; set; }
    }
}
