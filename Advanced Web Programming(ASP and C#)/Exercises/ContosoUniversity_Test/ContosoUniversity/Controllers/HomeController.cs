using ContosoUniversity.Data;
using ContosoUniversity.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ContosoUniversity.Controllers
{
    public class HomeController : Controller
    {
        private IRepositoryWrapper _repository;
        public HomeController(IRepositoryWrapper repository)
        {
            _repository = repository;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            IEnumerable<EnrollmentGroupViewModel> data = _repository.Student.FindAll()
                .GroupBy(e => e.EnrollmentDate.Year)
                .Select(e => new EnrollmentGroupViewModel
                {
                    EnrollmentYear = e.Key,
                    StudentCount = e.Count()
                });
            if (data == null)
                return NotFound();
            else
            {
                return View(data);
            }
        }

        public IActionResult Contact()
        {
            return View();
        }
    }
}
