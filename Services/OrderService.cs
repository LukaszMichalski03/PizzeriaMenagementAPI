using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PizzeriaManagementAPI.Entities;
using PizzeriaManagementAPI.Exceptions;
using PizzeriaManagementAPI.Interfaces;
using PizzeriaManagementAPI.Models;
using System.Linq;

namespace PizzeriaManagementAPI.Services
{
    public class OrderService : IOrderService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<DishService> _logger;

        public OrderService(DataContext context, IMapper mapper, ILogger<DishService> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task DeleteAsync(int id) //^
        {
            _logger.LogWarning($"Order with id: {id} Delete action invoked");
            Order? order = _context.Orders.FirstOrDefault(d => d.Id == id);
            if (order is null) throw new NotFoundException("Order with given id does not exist");
            _context.Remove(order);
            await _context.SaveChangesAsync();
        }
        public async Task<int> CreateAsync(CreateOrderDto dto) //^
        {
            List<int> existingDishIds = _context.Dishes.Select(d => d.Id).ToList();
            List<int> existingSizeIds = _context.Sizes.Select(d => d.Id).ToList();


            double totalPrice = 0;
            foreach(var itemDto in dto.OrderItems)
            {
                if (!existingDishIds.Contains(itemDto.DishId))
                {
                    throw new NotFoundException($"DishDto with id: {itemDto.DishId} not found!");
                }
                if(!existingSizeIds.Contains(itemDto.SizeId))
                {
                    throw new NotFoundException($"SizeDto with id: {itemDto.SizeId} not found!");
                }    
                double price = itemDto.DishPrice * itemDto.PriceModifier;
                totalPrice += price;
            }
            var order = _mapper.Map<Order>(dto);
            order.TotalPrice = totalPrice;
            _context.Add(order);
            await _context.SaveChangesAsync();

            return order.Id;
        }

        public async Task<List<OrderDto>> GetAllAsync()// ^
        {
            var orders = await _context.Orders
             .Include(o => o.CustomerData)
             .Include(o => o.OrderItems)
                 .ThenInclude(oi => oi.Dish)
             .Include(o => o.OrderItems)
                 .ThenInclude(oi => oi.Size)
             .ToListAsync();


            var ordersDto = _mapper.Map<List<OrderDto>>(orders);

            return ordersDto;
        }
        public async Task<OrderDto> GetByIdAsync(int id) //^
        {
            var order = await _context.Orders
             .Include(o => o.CustomerData)
             .Include(o => o.OrderItems)
                 .ThenInclude(oi => oi.Dish)
             .Include(o => o.OrderItems)
                 .ThenInclude(oi => oi.Size).FirstOrDefaultAsync(o => o.Id == id);
            if (order is null) throw new NotFoundException("Order not found!");
            var orderDto = _mapper.Map<OrderDto>(order);

            return orderDto;
        }
        public async Task UpdateAsync(int id, CreateOrderDto dto)
        {
            var order = await _context.Orders
              .Include(o => o.CustomerData)
              .Include(o => o.OrderItems)
                  .ThenInclude(oi => oi.Dish)
              .Include(o => o.OrderItems)
                  .ThenInclude(oi => oi.Size).FirstOrDefaultAsync(o => o.Id == id);
            var dtoOrderItemIds = new HashSet<int>(dto.OrderItems.Select(oi => oi.Id));
            if (order is null) throw new NotFoundException("Order with given id does not exist");
            if(dto.CustomerData != null)
            {
                if (order.CustomerData is null) order.CustomerData = new CustomerData();
                order.CustomerData.FirstName = dto.CustomerData.FirstName;
                order.CustomerData.LastName = dto.CustomerData.LastName;
                order.CustomerData.PhoneNumber = dto.CustomerData.PhoneNumber;
                order.CustomerData.City = dto.CustomerData.City;
                order.CustomerData.Street = dto.CustomerData.Street;
                order.CustomerData.PostalCode = dto.CustomerData.PostalCode;
                order.CustomerData.HouseNumber = dto.CustomerData.HouseNumber;
            }
            foreach (var orderItem in order.OrderItems)
            {
                if (!dtoOrderItemIds.Contains(orderItem.Id))
                {
                    _context.Remove(orderItem);
                }
            }
            double totalprice = 0;
            foreach (var orderItemDto in dto.OrderItems)
            {
                int dtoId = orderItemDto.Id;
                OrderItem? existingOrderItem = await _context.OrderItems.FirstOrDefaultAsync(oi => oi.Id == dtoId);
                if(existingOrderItem != null)
                {
                    existingOrderItem.SizeId = orderItemDto.SizeId;
                    existingOrderItem.DishId = orderItemDto.DishId;
                }
                else
                {
                    var orderItem = _mapper.Map<OrderItem>(orderItemDto);
                    order.OrderItems.Add(orderItem);
                    //_context.Add(orderItemDto);
                }
                totalprice += orderItemDto.DishPrice * orderItemDto.PriceModifier;
            }
            order.TotalPrice = totalprice;
            

            await _context.SaveChangesAsync();
        }
    }
}
