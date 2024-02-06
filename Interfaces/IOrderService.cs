using PizzeriaManagementAPI.Models;

namespace PizzeriaManagementAPI.Interfaces
{
    public interface IOrderService
    {
        Task<List<OrderDto>> GetAllAsync();
        Task<OrderDto> GetByIdAsync(int id);
        Task<int> CreateAsync(CreateOrderDto dto);
        Task DeleteAsync(int id);
        
        Task UpdateAsync(int id, CreateOrderDto dto);
    }
}
