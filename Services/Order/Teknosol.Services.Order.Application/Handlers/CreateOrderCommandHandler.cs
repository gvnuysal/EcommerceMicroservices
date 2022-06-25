using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Teknosol.Services.Order.Domain.OrderAggregate;
using Teknosol.Services.Order.Application.Commands;
using Teknosol.Services.Order.Application.Dtos;
using Teknosol.Services.Order.Infrastructure;
using Teknosol.Shared.Dtos;

namespace Teknosol.Services.Order.Application.Handlers
{
    public class CreateOrderCommandHandler:IRequestHandler<CreateOrderCommand,Response<CreatedOrderDto>>
    {
        private readonly OrderDbContext _orderDbContext;

        public CreateOrderCommandHandler(OrderDbContext orderDbContext)
        {
            _orderDbContext = orderDbContext;
        }

        public async Task<Response<CreatedOrderDto>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var newAddress = new Address(request.Address.Provience, request.Address.District, request.Address.Street, request.Address.ZipCode,
                request.Address.AddressLine);
            Domain.OrderAggregate.Order newOrder = new Domain.OrderAggregate.Order(request.BuyerId, newAddress);
            foreach (var requestOrderItem in request.OrderItems)
            {
                newOrder.AddOrderItem(requestOrderItem.ProductId, requestOrderItem.ProductName, requestOrderItem.Price, requestOrderItem.PictureUrl);
            }

            await _orderDbContext.Orders.AddAsync(newOrder,cancellationToken);
            await _orderDbContext.SaveChangesAsync(cancellationToken);

            return Response<CreatedOrderDto>.Success(new CreatedOrderDto() { OrderId = newOrder.Id },200,1);
        }
    }
}