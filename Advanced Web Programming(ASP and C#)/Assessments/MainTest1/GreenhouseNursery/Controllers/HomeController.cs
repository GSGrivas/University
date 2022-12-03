using Microsoft.AspNetCore.Mvc;

namespace GreenhouseNursery.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
