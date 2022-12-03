using BookCollection.Data;
using BookCollection.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookCollection.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookRepository _bookRepository;

        public BooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public IActionResult Library()
        {
            return View(_bookRepository.GetAllBooks()
                .Where(p => p.BookIsRead==true)
                .OrderBy(p => p.BookTitle));
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Book book)
        {
            try
            {
                _bookRepository.AddBook(book);
                return View("Confirmation", book);
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Unable to add book. " +
                    "Try again, and if the problem persists, " +
                    "see your system administrator.");
            }
            return View(book);
        }
    }
}
