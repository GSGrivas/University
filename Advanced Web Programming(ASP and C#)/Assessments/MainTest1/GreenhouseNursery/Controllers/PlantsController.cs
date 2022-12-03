using GreenhouseNursery.Data;
using GreenhouseNursery.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace GreenhouseNursery.Controllers
{
    public class PlantsController : Controller
    {
        private readonly IPlantRepository _plantRepository;

        public PlantsController(PlantRepository plantRepository)
        {
            _plantRepository = plantRepository;
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Plant plant)
        {
            plant.PlantDateAdded = DateTime.Now;
            if (ModelState.IsValid)
            {
                try
                {
                    _plantRepository.AddPlant(plant);
                    return RedirectToAction("List");
                }
                catch (DbUpdateException)
                {
                    ModelState.AddModelError("", "Unable to add plant. " +
                        "Try again, and if the problem persists, " +
                        "see your system administrator.");
                }
            }
            return View();
        }

        public IActionResult Details(int id)
        {
            var plant = _plantRepository.GetPlantWithCategoryDetails(id);
            if (plant == null)
                return NotFound();
            else
                return View(plant);
        }

        public IActionResult List()
        {
            return View(_plantRepository.GetPlantsWithCategoryDetails().OrderBy(p => p.PlantPrice));
        }

        public IActionResult ViewInCategory(int id)
        {
            ViewData["CategoryName"] = _plantRepository.GetCategory(id).CategoryName;
            return View(_plantRepository.GetPlantsInCategory(id).OrderBy(p => p.PlantCommonName));
        }
    }
}
