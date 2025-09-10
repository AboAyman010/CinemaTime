using CinemaTime.DataAccess;
using CinemaTime.Models;
using CinemaTime.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CinemaTime.Areas.Admin.Controllers
{
    [Area(SD.AdminArea)]
    [Authorize(Roles = $"{SD.SuperAdminRole},{SD.AdminArea}")]


    public class MovieController : Controller
    {
        //private ApplicationDbContext _context = new();
        private IMovieRepositories _movieRepositories;//= new MovieRepositories();
        private IRepository<Category> _categoryRepositories; //= new Repository<Category>();

        public MovieController(IMovieRepositories movieRepositories,
           IRepository<Category> categoryRepositories)
        {
            _movieRepositories = movieRepositories;
            _categoryRepositories = categoryRepositories;
        }

        public async Task<IActionResult> Index()
        {
            var movies = await _movieRepositories.GetAsync(includes: [e => e.Category]);
            return View(movies);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var categories =await _categoryRepositories.GetAsync();
          
            CategoryWithSessionVM categoryWithSessionVM = new()
            {
                Categories = categories.ToList(),

            };
            return View(categoryWithSessionVM);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Movie movie, IFormFile PosterUrl)
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
              await  _movieRepositories.CreateAsync(movie);
                await _movieRepositories.CommitAsync();
                return RedirectToAction(nameof(Index));
            }
            return BadRequest();
         
        }
        public async Task<IActionResult> Edit(int id)
        {
            var Movies = await _movieRepositories.GetOneAsync(e => e.MovieId == id);
            if (Movies is null)
            {
                return RedirectToAction(SD.NotFoundPage, SD.HomeController);
            }
            return View(Movies);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Movie movie, IFormFile? PosterUrl)
        {
            //   var moviesInDb=_context.Movies.AsNoTracking().FirstOrDefault(e => e.MovieId == movie.MovieId );
            var moviesInDb =  await   _movieRepositories.GetOneAsync(e => e.MovieId == movie.MovieId, tracked: false);
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

            _movieRepositories.Update(movie);
            await _movieRepositories.CommitAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int id)
        {
            var Movies = await _movieRepositories.GetOneAsync(e => e.MovieId == id);
            if (Movies is null)

                return RedirectToAction(SD.NotFoundPage, SD.HomeController);


            _movieRepositories.Delete(Movies);
            await _movieRepositories.CommitAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
