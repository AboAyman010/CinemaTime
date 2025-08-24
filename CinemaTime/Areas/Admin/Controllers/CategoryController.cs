using CinemaTime.DataAccess;
using CinemaTime.Models;
using Microsoft.AspNetCore.Mvc;

namespace CinemaTime.Areas.Admin.Controllers
{
    [Area(SD.AdminArea)]
    public class CategoryController : Controller
    {
        private ApplicationDbContext _context = new();
        public IActionResult Index()
        {
            var categorys = _context.Categorys;
            return View(categorys.ToList());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            _context.Categorys.Add(category);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
           var category= _context.Categorys.FirstOrDefault(e => e.CategoryId == id);
            if(category is null)
            {
                return RedirectToAction(SD.NotFoundPage, SD.HomeController);
            }
            return View(category);
        }
        [HttpPost]
        public IActionResult Edit(Category category)
        {
            _context.Categorys.Update(category);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {
            var category = _context.Categorys.FirstOrDefault(e => e.CategoryId == id);
            if (category is null)
            
                return RedirectToAction(SD.NotFoundPage, SD.HomeController);
            
            _context.Categorys.Remove(category);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }   
}
