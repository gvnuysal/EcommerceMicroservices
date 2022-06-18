using System.Collections.Generic;
using MediatR;
using Teknosol.Services.Order.Application.Dtos;
using Teknosol.Shared.Dtos;

namespace Teknosol.Services.Order.Application.Commands
{
    public abstract class CreateOrderCommand:IRequest<Response<CreatedOrderDto>>
    {
        public string BuyerId { get; set; }
        public List<OrderItemDto> OrderItems { get; set; }
        public AddressDto Address { get; set; }
    }
}