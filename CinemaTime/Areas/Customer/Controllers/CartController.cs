using CinemaTime.Models;
using CinemaTime.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CinemaTime.Areas.Customer.Controllers
{
    [Area(SD.CustomerArea)]
    [Authorize]
    public class CartController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IRepository<Cart> _cartRepository;

        public CartController(UserManager<ApplicationUser> userManager, IRepository<Cart> cartRepository)
        {
            _userManager = userManager;
            _cartRepository = cartRepository;
        }
       
        public async Task<IActionResult> AddToCart(CartRequestVM cartRequestVM)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user is null)
            {
                return NotFound();
            }

            var cart = await _cartRepository.GetOneAsync(e => e.ApplicationUserId == user.Id && e.MovieId == cartRequestVM.MovieId);

            if (cart is not null)
            {
                cart.Count += cartRequestVM.Count;
            }
            else
            {
                await _cartRepository.CreateAsync(new()
                {
                    ApplicationUserId = user.Id,
                    MovieId = cartRequestVM.MovieId,
                    Count = cartRequestVM.Count
                });
            }


            await _cartRepository.CommitAsync();

            TempData["success-notification"] = "Add Product To Cart Successfully";
            return RedirectToAction("Index", "Home", new { area = "Customer" });
        }
    }
}
