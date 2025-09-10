using CinemaTime.DataAccess;
using CinemaTime.IRepositories;
using CinemaTime.Models;
using CinemaTime.Repositories.IRepositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;
using System.Threading.Tasks;


namespace CinemaTime.Areas.Admin.Controllers
{
    [Area(SD.AdminArea)]
    [Authorize(Roles = $"{SD.SuperAdminRole},{SD.AdminArea}")]

    public class CategoryController : Controller
    {
        //private ApplicationDbContext _context = new();
        private IRepository<Category> _categoryRepositories;//= new Repository<Category>();
        public CategoryController(IRepository<Category> categoryRepositories)
        {
            _categoryRepositories = categoryRepositories;
        }
        public async Task<IActionResult> Index()
        {
            var categorys =  await  _categoryRepositories.GetAsync();
            return View(categorys);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View(new Category());
        }
        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(e => e.Errors);
                TempData["error-notification"] = String.Join(", ", errors.Select(e => e.ErrorMessage));
                return View(category);
            }
            await _categoryRepositories.CreateAsync(category);
            await _categoryRepositories.CommitAsync();
             TempData["success-notification"] = "Add Category Successfully";
            Response.Cookies.Append("success-notification", "Add Category Successfully", new()
            {
                Secure = true,
                Expires = DateTime.Now.AddDays(1)
            });
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var category = await _categoryRepositories.GetOneAsync(e => e.CategoryId==id);
            if(category is null)
            {
                return RedirectToAction(SD.NotFoundPage, SD.HomeController);
            }
            return View(category);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Category category)
        {
           _categoryRepositories.Update(category);
            await _categoryRepositories.CommitAsync();
            TempData["success-notification"] = "Update Category Successfully";
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _categoryRepositories.GetOneAsync(e => e.CategoryId == id);
            if (category is null)
            
                return RedirectToAction(SD.NotFoundPage, SD.HomeController);

            _categoryRepositories.Delete(category);
            await _categoryRepositories.CommitAsync();

            TempData["success-notification"] = "Delete Category Successfully";
            return RedirectToAction(nameof(Index));
        }
    }   
}
