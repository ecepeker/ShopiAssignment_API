using AutoMapper;
using ShopiAssignment.Data;
using ShopiAssignment.Dtos;
using ShopiAssignment.Models;

namespace ShopiAssignment.Profiles
{
    public class OrdersProfile : Profile
    {
        public OrdersProfile()
        {
            //source->target
            CreateMap<Order, OrderReadDto>();
            CreateMap<OrderFilterDto, OrderFilterModel>();
            CreateMap<OrderFilterDto, OrderReadDto>();
            CreateMap<OrderCreateDto, Order>();

        }
    }
}
