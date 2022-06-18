using System;
using System.Collections.Generic;
using Teknosol.Services.Order.Domain.OrderAggregate;

namespace Teknosol.Services.Order.Application.Dtos
{
    public class OrderDto
    {
        public int  Id { get; set; }
        public DateTime CreatedDate { get;private set; }
        public AddressDto Address { get;private set; }
        public string BuyerId { get;private set; }
        public List<OrderItemDto> OrderItems { get; set; }
    }
}