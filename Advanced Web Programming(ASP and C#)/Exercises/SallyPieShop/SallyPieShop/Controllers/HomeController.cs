using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SallyPieShop.Models;

namespace SallyPieShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPieRepository _pieRepository;

        public HomeController(IPieRepository pieRepository)
        {
            _pieRepository = pieRepository;
        }
        public IActionResult Index()
        {
            return View(_pieRepository.AllPies.OrderBy(p => p.Name));
        }

        public IActionResult Details(int id)
        {
            var pie = _pieRepository.GetPieById(id);
            if (pie == null)
                return NotFound();

            return View(pie);
        }

        public IActionResult PiesOfTheWeek()
        {
            return View(_pieRepository.PiesOfTheWeek.OrderBy(p => p.Name));
        }
    }
}
