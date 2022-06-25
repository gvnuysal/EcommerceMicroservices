using Microsoft.AspNetCore.Mvc;
using Teknosol.Shared.Dtos;

namespace Teknosol.Services.FakePayment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FakePaymentController : ControllerBase
    {
        [HttpPost]
        public IActionResult ReceivePayment()
        {
            return Ok(Response<NoContent>.Success(200));
        }
    }
}