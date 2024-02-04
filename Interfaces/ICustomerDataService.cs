using PizzeriaManagementAPI.Models;

namespace PizzeriaManagementAPI.Interfaces
{
    public interface ICustomerDataService
    {
        Task<int> CreateAsync(EditCustomerDataDto dto);
        Task DeleteAsync(int id);
        Task<List<CustomerDataDto>> GetAllAsync();
        Task<CustomerDataDto> GetByIdAsync(int id);
        Task UpdateAsync(int id, EditCustomerDataDto dto);
    }
}
