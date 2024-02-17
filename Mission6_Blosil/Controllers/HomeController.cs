using Microsoft.AspNetCore.Mvc;
using Mission6_Blosil.Models;
using System.Diagnostics;

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
        public IActionResult Movies()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Movies(MovieSubmission response)
        {
            if (!ModelState.IsValid)
            {
                // Model validation failed, return to the view with the current model to show validation messages
                return View(response);
            }
            else
            {
                _context.MovieSubmission.Add(response); //Add record to database
                _context.SaveChanges();
            }

            return View("MovieSubmitted");
        }
    }
}
