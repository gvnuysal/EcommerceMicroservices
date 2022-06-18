using AutoMapper;
using Teknosol.Services.Order.Domain.OrderAggregate;
using Teknosol.Services.Order.Application.Dtos;

namespace Teknosol.Services.Order.Application.Mapping
{
    public class CustomMapping:Profile
    {
        public CustomMapping()
        {
            CreateMap<Domain.OrderAggregate.Order, OrderDto>().ReverseMap();
            CreateMap<OrderItem, OrderItemDto>().ReverseMap();
            CreateMap<Address, AddressDto>().ReverseMap();
        }
    }
}