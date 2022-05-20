using AutoMapper;
using Teknosol.Service.Order.Domain.OrderAggregate;
using Teknosol.Services.Order.Application.Dtos;

namespace Teknosol.Services.Order.Application.Mapping
{
    public class CustomMapping:Profile
    {
        public CustomMapping()
        {
            CreateMap<Service.Order.Domain.OrderAggregate.Order, OrderDto>();
            CreateMap<OrderItem, OrderItemDto>();
        }
    }
}