using Microsoft.AspNetCore.Mvc;

namespace ConferenceManager.Controllers.Home
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult News()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }
    }
}
