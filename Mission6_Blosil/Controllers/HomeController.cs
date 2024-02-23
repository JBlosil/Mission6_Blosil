using Microsoft.AspNetCore.Mvc;
using Mission6_Blosil.Models;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

namespace Mission6_Blosil.Controllers
{
    public class HomeController : Controller
    {
        private MovieSubmissionContext _context;
        public HomeController(MovieSubmissionContext temp)
        {
            _context = temp;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MovieForm()
        {
            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName).ToList();

            return View(new Movie());
        }

        [HttpPost]
        public IActionResult MovieForm(Movie response)
        {
            if (!ModelState.IsValid)
            {
                // Model validation failed, return to the view with the current model to show validation messages
                return View(response);
            }
            else
            {
                _context.Movies.Add(response); //Add record to database
                _context.SaveChanges();
            }

            return View("MovieSubmitted");
        }

        public IActionResult MovieTable()
        {
            var movies = _context.Movies
                 .OrderBy(x => x.Category).ToList();

            return View(movies);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var recordEdit = _context.Movies
                .Single(x => x.MovieId == id);

            ViewBag.Categories = _context.Categories
            .OrderBy(x => x.CategoryName).ToList();

            return View("MovieForm", recordEdit);
        }

        [HttpPost]
        public IActionResult Edit(Movie updatedInfo)
        {
            _context.Update(updatedInfo);
            _context.SaveChanges();

            return RedirectToAction("MovieTable");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var recordDelete = _context.Movies
            .Single(x => x.MovieId == id);

            return View(recordDelete);
        }

        [HttpPost]
        public IActionResult Delete(Movie appID)
        {
            _context.Movies.Remove(appID);
            _context.SaveChanges();

            return RedirectToAction("MovieTable");
        }
    }
}
