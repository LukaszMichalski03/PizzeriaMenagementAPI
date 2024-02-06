using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PizzeriaManagementAPI.Controllers;
using PizzeriaManagementAPI.Entities;
using PizzeriaManagementAPI.Exceptions;
using PizzeriaManagementAPI.Interfaces;
using PizzeriaManagementAPI.Models;

namespace PizzeriaManagementAPI.Services
{
    public class DishService : IDishService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<DishService> _logger;

        public DishService(DataContext context, IMapper mapper, ILogger<DishService> logger)
        {
            _context = context;
            _mapper = mapper;
            this._logger = logger;
        }
        public async Task DeleteAsync(int id)
        {
            _logger.LogWarning($"DishDto with id: {id} Delete action invoked");
            Dish? dish = _context.Dishes.FirstOrDefault(d => d.Id == id);
            if (dish is null) throw new NotFoundException("DishDto with given id does not exist");
            _context.Remove(dish);
            await _context.SaveChangesAsync();
        }
        public async Task<int> CreateAsync(EditDishDto dto)
        {
            var dish = _mapper.Map<Dish>(dto);
            await _context.Dishes.AddAsync(dish);
            await _context.SaveChangesAsync();   

            return dish.Id;
        }

        public async Task<List<DishDto>> GetAllAsync()
        {
            var dishes = await _context.Dishes.ToListAsync();
            var dishesDto = _mapper.Map<List<DishDto>>(dishes);

            return dishesDto;
        }
        public async Task<DishDto> GetByIdAsync(int id)
        {
            var dish = await _context.Dishes.FirstOrDefaultAsync(x => x.Id == id);
            if (dish is null) throw new NotFoundException("DishDto not found!");
            var dishDto = _mapper.Map<DishDto>(dish);

            return dishDto;
        }
        public async Task UpdateAsync(int id, EditDishDto dto)
        {
            var dish = await _context.Dishes.FirstOrDefaultAsync(d =>  d.Id == id);
            if (dish is null) throw new NotFoundException("DishDto with given id does not exist");
            dish.Name = dto.Name;
            dish.Description = dto.Description;
            dish.Price = dto.Price;

            await _context.SaveChangesAsync();
        }
    }
}
