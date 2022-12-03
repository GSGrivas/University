using ConferenceManager.Data;
using ConferenceManager.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConferenceManager.Controllers
{
    [Authorize(Roles ="Author")]
    public class PapersController : Controller
    {
        private IRepositoryWrapper _repository;
        public PapersController(IRepositoryWrapper repository)
        {
            _repository = repository;
        }


        [TempData]
        public string Message { get; set; }

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View(_repository.Paper.FindAll());
        }

        [Authorize(Roles = "Author")]
        public IActionResult Submit()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Author")]
        public IActionResult Submit(Paper paper)
        {
            try
            {
                //Remember to log the date when something is submitted
                paper.PaperDateSubmitted = DateTime.Now;
                if (ModelState.IsValid)
                {
                    _repository.Paper.Create(paper);
                    _repository.Paper.Save();

                    Message = "Paper" + paper.PaperId + "was submitted";
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists, " +
                    "see your system administrator.");
            }

            return View();
        }

        public IActionResult Edit(int id)
        {
            var paper = _repository.Paper.GetById(id);
            if (paper == null)
            {
                return NotFound();
            }
            //PopulateDropDownList
            PopulateTopicDropDownList(paper.TopicId);
            return View(paper);
        }

        
        [HttpPost]
        public IActionResult Edit(Paper paper)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _repository.Paper.Update(paper);
                    _repository.Paper.Save();

                    Message = "Paper {paper.PaperId}  updated succesfully";
                    return RedirectToAction("MyPapers");
                }
                catch (DbUpdateException)
                {
                    ModelState.AddModelError("", "Unable to save changes. " +
                        "Try again, and if the problem persists, " +
                        "see your system administrator.");
                }
            }
            PopulateTopicDropDownList(paper.TopicId);
            return View(paper);
        }


        public IActionResult MyPapers(string Author)
        {
            ViewData["Message"] = Message;
            return View(_repository.Paper.GetAllPapersWithTopicDetails()
                .Where(p => p.PaperAuthor == User.Identity.Name)
                .OrderBy(p => p.PaperTitle));
        }

        [Authorize(Roles = "Author")]
        public IActionResult Delete(int paperId)
        {
            var paper = _repository.Paper.GetById(paperId);
            try
            {
                _repository.Paper.Delete(paper);
                _repository.Paper.Save();

                Message = $"Paper { paper.PaperId}  deleted succesfully";
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Unable to delete paper. " +
                    "Try again, and if the problem persists, " +
                    "see your system administrator.");
            }
            return RedirectToAction("MyPapers");
        }

        private void PopulateTopicDropDownList(int selectedTopic = 0)
        {
            var topics = _repository.Topic.FindAllSorted("TopicName");
            ViewBag.TopicId = new SelectList(topics, "TopicId", "TopicName", selectedTopic);
        }
    }
}
