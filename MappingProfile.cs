using AutoMapper;
using PizzeriaManagementAPI.Entities;
using PizzeriaManagementAPI.Models;
using System.Net;

namespace PizzeriaManagementAPI
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Dish, DishDto>();
            CreateMap<EditDishDto, Dish>();

            CreateMap<Size, SizeDto>();
            CreateMap<EditSizeDto, Size>();

            CreateMap<CustomerData, CustomerDataDto>();
            CreateMap<EditCustomerDataDto, CustomerData>();

            CreateMap<OrderItemDto, OrderItem>()
            .ForMember(dest => dest.Dish, opt => opt.MapFrom(src => src.Dish))
            .ForMember(dest => dest.Size, opt => opt.MapFrom(src => src.Size));

            CreateMap<EditOrderItemDto, OrderItem>()
                .ForMember(dest => dest.Dish, opt => opt.MapFrom(src => src.Dish))
                .ForMember(dest => dest.Size, opt => opt.MapFrom(src => src.Size));
        }
    }
}
