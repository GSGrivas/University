using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SportsStore.Data;
using SportsStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Controllers
{
    public class AdminController : Controller
    {
        private IRepositoryWrapper _repository;
        public AdminController(IRepositoryWrapper repo)
        {
            _repository = repo;
        }

        public IActionResult Index()
        {
            return View(_repository.Product.FindAll());     
        }
        public IActionResult Add()
        {
            ViewBag.Title = "Add Product";
            return RedirectToAction("Edit");
        }

        public IActionResult Edit(int id)
        {
            var product = _repository.Product.GetById(id);
            if (product == null)
            {
                return NotFound();
            }

            ViewBag.Title = "Edit Product";
            PopulateCategoryDDL(product.CategoryID);
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _repository.Product.Update(product);
                _repository.Product.Save();
                TempData["Message"] = $"{product.Name} has been saved";
                return RedirectToAction("Index");
            }
            return View(product);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var product = _repository.Product.GetById(id);

            if (product != null)
            {
                try
                {
                    _repository.Product.Delete(product);
                    _repository.Product.Save();
                    TempData["Message"] = $"{product.Name} has been deleted";
                }
                catch
                {
                    TempData["Message"] = $"Unable to Delete product {product.Name}";
                }              
            }
            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            PopulateCategoryDDL();
            ViewBag.Title = "Add Product";
            return View("Edit", new Product());
        }

            private void PopulateCategoryDDL(object selectedCategory = null)
        {
            ViewBag.CategoryID = new SelectList(_repository.Category.FindAll(), "CategoryID", "CategoryName", selectedCategory);
        }
    }
}
