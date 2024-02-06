namespace PizzeriaManagementAPI.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public double TotalPrice { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
        public int? CustomerDataId { get; set; }
        public CustomerData? CustomerData { get; set; }
    }
}
