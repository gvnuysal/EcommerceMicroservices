using Microsoft.AspNetCore.Mvc;

namespace Teknosol.Services.FakePayment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FakePaymentController : ControllerBase
    {
        [HttpPost]
        public IActionResult ReceivePayment()
        {
            return Ok(true);
        }
    }
}