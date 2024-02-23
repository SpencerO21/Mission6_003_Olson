using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            ViewBag.categories = _context.Categories.ToList();
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

        [HttpGet]
        public IActionResult AddMovie()
        {
            ViewBag.categories = _context.Categories.ToList();
            return View("MovieForm");
        }

        public IActionResult MovieList()
        {
            List<Movie> movies = _context.Movies.Include(m => m.Category).ToList();

            return View(movies);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Movie recordToEdit = _context.Movies
                .Include(m => m.Category)
                .Single(x => x.MovieId == id);

            ViewBag.categories = _context.Categories.ToList();
            return View("MovieForm", recordToEdit);
        }

        [HttpPost]
        public IActionResult Edit(Movie movie)
        {
            _context.Update(movie);
            _context.SaveChanges();
            return RedirectToAction("MovieList");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Movie recordToDelete = _context.Movies
                .Single(x => x.MovieId == id);

            return View("Confirmation", recordToDelete);
        }

        [HttpPost]
        public IActionResult Delete(Movie movie)
        {
            _context.Remove(movie);
            _context.SaveChanges();
            return RedirectToAction("MovieList");
        }

    }
}
