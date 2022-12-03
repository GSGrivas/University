using System;
using System.Linq;
using ContosoUniversity.Data;
using ContosoUniversity.Models;
using ContosoUniversity.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContosoUniversity.Controllers
{
    public class StudentsController : Controller
    {
        private IRepositoryWrapper _repository;
        public StudentsController(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        public int iPageSize = 3;

        [TempData] /*Assigned value will only be available until next request */
        public string Message { get; set; }

        public IActionResult Index(string sortBy, string searchString, int page = 1)
        {
            ViewData["NameSortParam"] = string.IsNullOrEmpty(sortBy) ?
            "LastName_desc" : "";
            ViewData["DateSortParam"] = sortBy == "EnrollmentDate" ? "EnrollmentDate_desc" :
            "EnrollmentDate";
            ViewData["CurrentFilter"] = searchString;
            ViewData["Message"] = Message;

            if (string.IsNullOrEmpty(sortBy))
            {
                sortBy = "LastName";
            }

            if (searchString == null)
                searchString = "";

            bool isDescending = false;
            if (sortBy.EndsWith("_desc"))
            {
                sortBy = sortBy.Substring(0, sortBy.Length - 5);
                isDescending = true;
            }

            if (isDescending)
            {
                return View(new StudentsListViewModel
                {
                    Students = _repository.Student.FindByConditionDesc(s =>
                                    s.LastName.Contains(searchString) ||
                                    s.FirstName.Contains(searchString), sortBy)
                                .Skip((page - 1) * iPageSize)
                                .Take(iPageSize),
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = iPageSize,
                        TotalItems = _repository.Student.FindByConditionDesc(s =>
                                    s.LastName.Contains(searchString) ||
                                    s.FirstName.Contains(searchString), sortBy)
                                    .Count()
                    }
                });
            }
            else
            {
                return View(new StudentsListViewModel
                {
                    Students = _repository.Student.FindByConditionAsce(s =>
                                    s.LastName.Contains(searchString) ||
                                    s.FirstName.Contains(searchString), sortBy)
                                .Skip((page - 1) * iPageSize)
                                .Take(iPageSize),
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = iPageSize,
                        TotalItems = _repository.Student.FindByConditionAsce(s =>
                                    s.LastName.Contains(searchString) ||
                                    s.FirstName.Contains(searchString), sortBy)
                                    .Count()
                    }
                });
            }
        } 

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Student student)
        {
            student.EnrollmentDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                _repository.Student.Create(student);
                _repository.Student.Save();
                Message = "Student added succesfully";
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Edit(int id)
        {
            return View(_repository.Student.GetById(id));
        }

        [HttpPost]
        public IActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _repository.Student.Update(student);
                    _repository.Student.Save();
                    Message = "Student updated succesfully.";
                    return RedirectToAction("Index");
                }
                catch (DbUpdateException)
                {
                    ModelState.AddModelError("", "Unable to save changes. " +
                        "Try again, and if the problem persists, " +
                        "see your system administrator.");
                }
            }
            return View(student);
        }

        public IActionResult Details(int id)
        {
            var student = _repository.Student.GetStudentWithEnrollmentDetails(id);
            if (student == null)
                return NotFound();
            else
            {
                return View(student);
            }
        }

        public IActionResult Delete(int id)
        {
            var student = _repository.Student.GetById(id);
            if (student == null)
                return NotFound();
            else
            {
                return View(student);
            }
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteStudent(Student student)
        {
            if (student != null)
            {
                _repository.Student.Delete(student);
                _repository.Student.Save();
                Message = "Student deleted successfully";
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.ErrorMessage = "Unable to Delete student";
                return View(student);
            }

        }
    }
}
