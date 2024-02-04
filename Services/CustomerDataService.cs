using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PizzeriaManagementAPI.Entities;
using PizzeriaManagementAPI.Exceptions;
using PizzeriaManagementAPI.Interfaces;
using PizzeriaManagementAPI.Models;

namespace PizzeriaManagementAPI.Services
{
    public class CustomerDataService : ICustomerDataService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<DishService> _logger;

        public CustomerDataService(DataContext context, IMapper mapper, ILogger<DishService> logger)
        {
            _context = context;
            _mapper = mapper;
            this._logger = logger;
        }
        public async Task<List<CustomerDataDto>> GetAllAsync()
        {
            var customers = await _context.Customers.ToListAsync();
            var customersDto = _mapper.Map<List<CustomerDataDto>>(customers);
            return customersDto;
        }
        public async Task<CustomerDataDto> GetByIdAsync(int id)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(c => c.Id == id);
            if (customer == null) throw new NotFoundException("Customer with given id does not exist!");
            var customerDto = _mapper.Map<CustomerDataDto>(customer);
            return customerDto;
        }

        public async Task<int> CreateAsync(EditCustomerDataDto dto)
        {
            CustomerData customer = _mapper.Map<CustomerData>(dto);
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            return customer.Id;
        }

        public async Task DeleteAsync(int id)
        {
            _logger.LogWarning($"Customer with id: {id} Delete action invoked");
            var customer = await _context.Customers.FirstOrDefaultAsync(c => c.Id == id);
            if (customer is null) throw new NotFoundException("Customer with given id does not exist!");
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, EditCustomerDataDto dto)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(c => c.Id == id);
            if (customer is null) throw new NotFoundException("Customer with given id does not exist!");
            customer.PhoneNumber = dto.PhoneNumber;
            customer.FirstName = dto.FirstName;
            customer.LastName = dto.LastName;
            customer.City = dto.City;
            customer.Street = dto.Street;
            customer.HouseNumber = dto.HouseNumber;
            customer.PostalCode = dto.PostalCode;
            await _context.SaveChangesAsync();
        }
    }
}
