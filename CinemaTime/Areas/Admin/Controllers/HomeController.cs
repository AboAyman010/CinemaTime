using Microsoft.AspNetCore.Mvc;

namespace CinemaTime.Areas.Admin.Controllers
{
    [Area(SD.AdminArea)]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult NotFoundPage()
        {
            return View();
        }
    }
}
