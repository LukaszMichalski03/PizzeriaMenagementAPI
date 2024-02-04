using PizzeriaManagementAPI.Models;

namespace PizzeriaManagementAPI.Interfaces
{
    public interface ISizeService
    {
        Task<int> CreateAsync(EditSizeDto dto);
        Task DeleteAsync(int id);
        Task<IEnumerable<SizeDto>> GetAllAsync();
        Task<SizeDto> GetByIdAsync(int id);
        Task UpdateAsync(int id, EditSizeDto dto);
    }
}
