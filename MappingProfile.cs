using AutoMapper;
using PizzeriaManagementAPI.Entities;
using PizzeriaManagementAPI.Models;

namespace PizzeriaManagementAPI
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Dish, DishDto>();
        }
    }
}
