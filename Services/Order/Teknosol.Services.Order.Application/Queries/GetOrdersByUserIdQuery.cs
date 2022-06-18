using System.Collections.Generic;
using MediatR;
using Teknosol.Services.Order.Application.Dtos;
using Teknosol.Shared.Dtos;

namespace Teknosol.Services.Order.Application.Queries
{
    public class GetOrdersByUserIdQuery:IRequest<Response<List<OrderDto>>>
    {
        public string UserId { get; set; }
    }
}