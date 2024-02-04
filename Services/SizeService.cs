using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PizzeriaManagementAPI.Entities;
using PizzeriaManagementAPI.Exceptions;
using PizzeriaManagementAPI.Interfaces;
using PizzeriaManagementAPI.Models;

namespace PizzeriaManagementAPI.Services
{
    public class SizeService : ISizeService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<DishService> _logger;

        public SizeService(DataContext context, IMapper mapper, ILogger<DishService> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<IEnumerable<SizeDto>> GetAllAsync()
        {
            List<Size> sizes = await _context.Sizes.ToListAsync();
            List<SizeDto> sizesDto = _mapper.Map<List<SizeDto>>(sizes);

            return sizesDto;
        }
        public async Task<SizeDto> GetByIdAsync(int id)
        {
            var size = await _context.Sizes.FirstOrDefaultAsync(s => s.Id == id);
            if (size == null) throw new NotFoundException("Size with given id does not exist!");
            var sizeDto = _mapper.Map<SizeDto>(size);
            return sizeDto;
        }
        public async Task<int> CreateAsync(EditSizeDto dto)
        {
            Size size = _mapper.Map<Size>(dto);
            _context.Sizes.Add(size);
            await _context.SaveChangesAsync();

            return size.Id;
        }
        public async Task DeleteAsync(int id)
        {
            _logger.LogWarning($"Size with id: {id} Delete action invoked");
            var size = await _context.Sizes.FirstOrDefaultAsync(s => s.Id == id);
            if (size is null) throw new NotFoundException("Size with given id does not exist!");
            _context.Sizes.Remove(size);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(int id, EditSizeDto dto)
        {
            var size = await _context.Sizes.FirstOrDefaultAsync(s => s.Id == id);
            if (size is null) throw new NotFoundException("Size with given id does not exist!");
            size.Diameter = dto.Diameter;
            size.PriceModifier = dto.PriceModifier;
            await _context.SaveChangesAsync();
        }
    }
}
