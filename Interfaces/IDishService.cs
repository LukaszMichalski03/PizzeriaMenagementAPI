using PizzeriaManagementAPI.Models;

namespace PizzeriaManagementAPI.Interfaces
{
    public interface IDishService
    {
        Task<List<DishDto>> GetAllAsync();
        Task<DishDto> GetByIdAsync(int id);
        Task<int> CreateAsync(EditDishDto dto);
        Task DeleteAsync(int id);
        Task UpdateAsync(int id, EditDishDto dto);
    }
}
