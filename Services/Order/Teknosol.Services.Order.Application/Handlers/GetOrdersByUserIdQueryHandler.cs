using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Teknosol.Services.Order.Application.Dtos;
using Teknosol.Services.Order.Application.Mapping;
using Teknosol.Services.Order.Application.Queries;
using Teknosol.Services.Order.Infrastructure;
using Teknosol.Shared.Dtos;

namespace Teknosol.Services.Order.Application.Handlers
{
    public class GetOrdersByUserIdQueryHandler : IRequestHandler<GetOrdersByUserIdQuery, Response<List<OrderDto>>>
    {
        private readonly OrderDbContext _orderDbContext;

        public GetOrdersByUserIdQueryHandler(OrderDbContext orderDbContext)
        {
            _orderDbContext = orderDbContext;
        }

        public virtual async Task<Response<List<OrderDto>>> Handle(GetOrdersByUserIdQuery request, CancellationToken cancellationToken)
        {
            var orders = await _orderDbContext.Orders.Include(x => x.OrderItems).Where(x => x.BuyerId == request.UserId)
                .ToListAsync(cancellationToken);
            if (!orders.Any())
            {
                return Response<List<OrderDto>>.Success(new List<OrderDto>(), 200,orders.Count);
            }

            var ordersDto = ObjectMapper.Mapper.Map<List<OrderDto>>(orders);

            return Response<List<OrderDto>>.Success(ordersDto, 200);
        }
    }
}