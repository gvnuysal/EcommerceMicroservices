using Microsoft.AspNetCore.Mvc;

namespace Teknosol.Services.Catalog.Controllers
{
    public class HomeController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return Redirect("~/swagger");
        }
    }
}