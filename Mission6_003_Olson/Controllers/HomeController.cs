using Microsoft.AspNetCore.Mvc;
using Mission6_003_Olson.Models;
using System.Diagnostics;

namespace Mission6_003_Olson.Controllers
{
    public class HomeController : Controller
    {

        private MovieContext _context;
        public HomeController(MovieContext temp)
        {
            _context = temp;
        }


        [HttpPost]
        public IActionResult AddMovie(Movie response)
        {

            // Process the movie data 
            _context.Movies.Add(response);
            _context.SaveChanges();
            // Redirect to a success page or show a success message
            return View("MovieForm", response);
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult MovieForm()
        {
            return View();
        }

       
    }
}
