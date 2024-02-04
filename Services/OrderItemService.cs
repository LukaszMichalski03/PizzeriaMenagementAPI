using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PizzeriaManagementAPI.Entities;
using PizzeriaManagementAPI.Exceptions;
using PizzeriaManagementAPI.Interfaces;
using PizzeriaManagementAPI.Models;

namespace PizzeriaManagementAPI.Services
{
    public class OrderItemService : IOrderItemService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<DishService> _logger;

        public OrderItemService(DataContext context, IMapper mapper, ILogger<DishService> logger)
        {
            _context = context;
            _mapper = mapper;
            this._logger = logger;
        }
        public async Task<IEnumerable<OrderItemDto>> GetAllAsync()
        {
            List<OrderItem> orderItems = await _context.OrderItems.ToListAsync();
            List<OrderItemDto> orderItemsDto = _mapper.Map<List<OrderItemDto>>(orderItems);

            return orderItemsDto;
        }

        public async Task<OrderItemDto> GetByIdAsync(int id)
        {
            var orderItem = await _context.OrderItems.FirstOrDefaultAsync(o => o.Id == id);
            if (orderItem == null) throw new NotFoundException("OrderItem with given id does not exist!");
            var orderItemDto = _mapper.Map<OrderItemDto>(orderItem);
            return orderItemDto;
        }

        public async Task<int> CreateAsync(EditOrderItemDto dto)
        {
            OrderItem orderItem = _mapper.Map<OrderItem>(dto);
            _context.OrderItems.Add(orderItem);
            await _context.SaveChangesAsync();

            return orderItem.Id;
        }

        public async Task DeleteAsync(int id)
        {
            _logger.LogWarning($"OrderItem with id: {id} Delete action invoked");
            var orderItem = await _context.OrderItems.FirstOrDefaultAsync(o => o.Id == id);
            if (orderItem is null) throw new NotFoundException("OrderItem with given id does not exist!");
            _context.OrderItems.Remove(orderItem);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, EditOrderItemDto dto)
        {
            var orderItem = await _context.OrderItems.FirstOrDefaultAsync(o => o.Id == id);
            if (orderItem is null) throw new NotFoundException("OrderItem with given id does not exist!");

            //var size = _mapper.Map<Size>(dto.Size);
            //orderItem.Size = size;
            //orderItem.SizeId = size.Id;
            //orderItem.
            await _context.SaveChangesAsync();
        }

    }
}
