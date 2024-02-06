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

            CreateMap<CreateOrderItemDto, OrderItem>()
                .ForMember(oi => oi.DishId, x => x.MapFrom(oDto => oDto.DishId))
                .ForMember(oi => oi.SizeId, x => x.MapFrom(oDto => oDto.SizeId));
                
            //CreateMap<OrderItem, OrderItemDto>();

            CreateMap<Order, OrderDto>()
                .ForMember(od => od.CustomerDataDto, opt => opt.MapFrom(src => src.CustomerData))
                .ForMember(od => od.OrderItemsDto, x => x.MapFrom(o => o.OrderItems.Select(oi => new OrderItemDto
                {
                    DishId = oi.DishId,
                    DishDto = new DishDto
                    {
                        Id = oi.Dish.Id,
                        Name = oi.Dish.Name,
                        Description = oi.Dish.Description,
                        Price = oi.Dish.Price,
                    },
                    SizeId = oi.SizeId,
                    SizeDto = new SizeDto
                    {
                        Diameter = oi.Size.Diameter,
                        PriceModifier = oi.Size.PriceModifier,
                    }

                })));



            CreateMap<CreateOrderDto, Order>()
                .ForMember(o => o.CustomerData, c => c.MapFrom(dto => new CustomerData
                {
                    PhoneNumber = dto.CustomerData.PhoneNumber,
                    FirstName = dto.CustomerData.FirstName,
                    LastName = dto.CustomerData.LastName,
                    City = dto.CustomerData.City,
                    Street = dto.CustomerData.Street,
                    HouseNumber = dto.CustomerData.HouseNumber,
                    PostalCode = dto.CustomerData.PostalCode
                }))
                .ForMember(o => o.OrderItems, oi => oi.MapFrom(dto => dto.OrderItems.Select(oiDto => new OrderItem
                {
                    DishId = oiDto.DishId,
                    
                    SizeId = oiDto.SizeId,
                    
                })));

        }
    }
}
