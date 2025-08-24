using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CinemaTime.Models;
using CinemaTime.DataAccess;
using Microsoft.EntityFrameworkCore;
using CinemaTime.Models.ViewModel;

namespace CinemaTime.Areas.Customer.Controllers;
[Area(SD.CustomerArea)]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private ApplicationDbContext _Context = new();
    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index(MovieFilterVM movieFilterVM, int page = 1)
    {
        var Movie = _Context.Movies.Include(e => e.Category).Include(m => m.Sessions)
                             .ThenInclude(s => s.Hall).AsQueryable();
        if(movieFilterVM.MovieTitle is not null)
        {
            Movie = Movie.Where(e => e.Title.Contains(movieFilterVM.MovieTitle));
            ViewBag.MovieTitle = movieFilterVM.MovieTitle;
        }
        if (movieFilterVM.CategoryId is not null)
        {
            Movie = Movie.Where(e => e.CategoryId == movieFilterVM.CategoryId);
            ViewBag.CategoryId = movieFilterVM.CategoryId;

        }

        ViewBag.Categories = _Context.Categorys.ToList();


      


        //pagination
        double totalPages = Math.Ceiling(Movie.Count() / 3.0);
        int CurrentPage = page;
        ViewBag.totalPages = totalPages;
        ViewBag.CurrentPage = CurrentPage;
        Movie = Movie.Skip((page - 1) * 3).Take(3);

       

        return View(Movie.ToList());
    }
   
    public IActionResult Details(int id)
    {
        var movie = _Context.Movies
            .Include(m => m.Category)
            .Include(m => m.MovieActors)
                .ThenInclude(ma => ma.Actor)
            .FirstOrDefault(m => m.MovieId == id);

        if (movie == null) return NotFound();
        Console.WriteLine($"Actors count: {movie.MovieActors.Count}");

        return View(movie);

    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
