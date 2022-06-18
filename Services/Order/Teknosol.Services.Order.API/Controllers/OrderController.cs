using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Teknosol.Services.Order.Application.Commands;
using Teknosol.Services.Order.Application.Queries;
using Teknosol.Shared.Services;

namespace Teknosol.Services.Order.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ISharedIdentityService _sharedIdentityService;

        public OrderController(ISharedIdentityService sharedIdentityService, IMediator mediator)
        {
            _sharedIdentityService = sharedIdentityService;
            _mediator = mediator;
        }

        [HttpGet]
        public virtual async Task<IActionResult> GetOrders()
        {
            var response = await _mediator.Send(new GetOrdersByUserIdQuery{UserId = _sharedIdentityService.GetUserId});
            return Ok(response);
        }

        [HttpPost]
        public virtual async Task<IActionResult> SaveOrder(CreateOrderCommand createOrderCommand)
        {
            var response = await _mediator.Send(createOrderCommand);

            return Ok(response);
        }
    }
}