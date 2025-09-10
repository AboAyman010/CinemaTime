using CinemaTime.Models;
using CinemaTime.Models.ViewModel;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CinemaTime.Areas.Identity.Controllers
{
    [Area(SD.IdentityArea)]
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public ProfileController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user is null)
                return NotFound();

            var updateUser = user.Adapt<UpdatePersonalInfoVM>();

            return View(updateUser);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateInfo(UpdatePersonalInfoVM updatePersonalInfoVM)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", updatePersonalInfoVM);
            }

            var user = await _userManager.GetUserAsync(User);

            if (user is null)
                return NotFound();

            // تحديث البيانات الأساسية
            user.Name = updatePersonalInfoVM.Name;
            user.Email = updatePersonalInfoVM.Email;
            user.PhoneNumber = updatePersonalInfoVM.PhoneNumber;
            user.Street = updatePersonalInfoVM.Street;
            user.State = updatePersonalInfoVM.State;
            user.City = updatePersonalInfoVM.City;
            user.ZipCode = updatePersonalInfoVM.ZipCode;

            // التعامل مع رفع الصورة
            if (updatePersonalInfoVM.ProfileImage != null)
            {
                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images");

                if (!Directory.Exists(uploadsFolder))
                    Directory.CreateDirectory(uploadsFolder);

                var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(updatePersonalInfoVM.ProfileImage.FileName);
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await updatePersonalInfoVM.ProfileImage.CopyToAsync(fileStream);
                }

                // مسح الصورة القديمة لو موجودة
                if (!string.IsNullOrEmpty(user.ProfilePicture))
                {
                    var oldPath = Path.Combine(uploadsFolder, user.ProfilePicture);
                    if (System.IO.File.Exists(oldPath))
                    {
                        System.IO.File.Delete(oldPath);
                    }
                }

                user.ProfilePicture = uniqueFileName;
            }

            // تحديث المستخدم
            await _userManager.UpdateAsync(user);

            // تغيير الباسورد لو المستخدم دخّل القديم والجديد
            if (!string.IsNullOrWhiteSpace(updatePersonalInfoVM.CurrentPassword) &&
                !string.IsNullOrWhiteSpace(updatePersonalInfoVM.NewPassword))
            {
                var result = await _userManager.ChangePasswordAsync(
                    user,
                    updatePersonalInfoVM.CurrentPassword,
                    updatePersonalInfoVM.NewPassword
                );

                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    return View("Index", updatePersonalInfoVM);
                }
            }

            // تمرير الصورة الحالية عشان تعرض في الـ View
            updatePersonalInfoVM.ExistingImage = user.ProfilePicture;

            return RedirectToAction(nameof(Index), "Profile", new { area = "Identity" });
        }
    }
        
    }

