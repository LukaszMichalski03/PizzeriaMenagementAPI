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

        public DishService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<DishDto>> GetAllAsync()
        {
            var tasks = await _context.Dishes.ToListAsync();
            var tasksDto = _mapper.Map<List<DishDto>>(tasks);

            return tasksDto;
        }
        public async Task<DishDto> GetByIdAsync(int id)
        {
            var dish = await _context.Dishes.FirstOrDefaultAsync(x => x.Id == id);
            if (dish is null) throw new NotFoundException("Dish not found!");
            var dishDto = _mapper.Map<DishDto>(dish);

            return dishDto;
        }
    }
}
