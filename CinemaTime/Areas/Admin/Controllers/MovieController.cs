using CinemaTime.DataAccess;
using CinemaTime.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CinemaTime.Areas.Admin.Controllers
{
    [Area(SD.AdminArea)]

    public class MovieController : Controller
    {
        private ApplicationDbContext _context = new();

        public IActionResult Index()
        {
           var Movies= _context.Movies;
            return View(Movies.ToList());
        }
        [HttpGet]
        public IActionResult Create()
        {
            var Movies = _context.Movies.Include(m => m.Sessions)
        .ThenInclude(s => s.Hall);
            return View();
        }
        [HttpPost]
        public IActionResult Create(Movie movie)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int id)
        {
            var Movies = _context.Movies.FirstOrDefault(e => e.MovieId == id);
            if (Movies is null)
            {
                return RedirectToAction(SD.NotFoundPage, SD.HomeController);
            }
            return View(Movies);
        }
        [HttpPost]
        public IActionResult Edit(Movie movie)
        {
            _context.Movies.Update(movie);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {
            var Movies = _context.Movies.FirstOrDefault(e => e.MovieId == id);
            if (Movies is null)

                return RedirectToAction(SD.NotFoundPage, SD.HomeController);

            _context.Movies.Remove(Movies);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
