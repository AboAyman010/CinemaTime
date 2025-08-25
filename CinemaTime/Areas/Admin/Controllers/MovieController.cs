using CinemaTime.DataAccess;
using CinemaTime.Models;
using CinemaTime.Models.ViewModel;
using Microsoft.AspNetCore.Http;
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
            var categories = _context.Categorys;
            var Sessions = _context.Sessions;
            CategoryWithSessionVM categoryWithSessionVM = new()
            {
                Categories = categories.ToList(),
            };
            return View(categoryWithSessionVM);
        }
        [HttpPost]
        public IActionResult Create(Movie movie, IFormFile PosterUrl)
        {
            //save img in wwwrot
            if (PosterUrl is not null && PosterUrl.Length > 0)
            {
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(PosterUrl.FileName);
                var filePath =Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Images",
                    fileName);

                using (var stream = System.IO.File.Create(filePath))
                {
                    PosterUrl.CopyToAsync(stream);
                }
                movie.PosterUrl = fileName;
                _context.Movies.Add(movie);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return BadRequest();
         
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
        public IActionResult Edit(Movie movie, IFormFile? PosterUrl)
        {
            var moviesInDb=_context.Movies.AsNoTracking().FirstOrDefault(e => e.MovieId == movie.MovieId );
            if(moviesInDb is null)
            {
                return BadRequest();
            }
            //save img in wwwrot
            if (PosterUrl is not null && PosterUrl.Length > 0)
            {
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(PosterUrl.FileName);
                 
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Images",
                    fileName);

                using (var stream = System.IO.File.Create(filePath))
                {
                    PosterUrl.CopyTo(stream);
                }
                var OldFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Images",
                    moviesInDb.PosterUrl);
                if (System.IO.File.Exists(OldFilePath))
                {
                    System.IO.File.Delete(OldFilePath);
                }
                movie.PosterUrl = fileName;
            
            }
            else
            {
                movie.PosterUrl = moviesInDb.PosterUrl;
            }

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
