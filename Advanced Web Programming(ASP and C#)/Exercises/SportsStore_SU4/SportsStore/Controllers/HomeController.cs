using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Data;
using SportsStore.Models.ViewModels;

namespace SportsStore.Controllers
{
    public class HomeController : Controller
    {
        private IRepositoryWrapper _repository;
        public int iPageSize = 4;
        public HomeController(IRepositoryWrapper repo)
        {
            _repository = repo;
        }

        public IActionResult Index(int productPage = 1)
        {
            return View(new ProductsListViewModel
            {
                Products = _repository.Product.AllProducts
                              .OrderBy(p => p.ProductID)
                              .Skip((productPage - 1) * iPageSize)
                              .Take(iPageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = productPage,
                    ItemsPerPage = iPageSize,
                    TotalItems = _repository.Product.AllProducts.Count()
                }
            });
        }
    }
}
