using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NETMeetApp.Enums;
using NETMeetApp.Extensions;
using NETMeetApp.Models;
using NETMeetApp.ViewModels.Admin;
using NETMeetApp.ViewModels.SuperAdmin;
using NuGet.DependencyResolver;

namespace NETMeetApp.Areas.SuperAdmin.Controllers
{
    [Authorize(Roles = "SuperAdmin")]
    [Area("SuperAdmin")]
    public class DashBoardController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public DashBoardController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var Admins = _userManager.Users.Where(s => s.UserType == UserType.Admin).ToList();
            return View(Admins);
        }

        public async  Task<IActionResult> Create()
        {
            var existUser = await _userManager.GetUserAsync(User);
            ViewBag.User = existUser;
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(AppUserAdminCreateVM user)
        {
            var existUser = await _userManager.GetUserAsync(User);
            ViewBag.User = existUser;
            if (!ModelState.IsValid) return View(user);

            var file = user.ProfileImage;
            if (file == null)
            {
                ModelState.AddModelError("ProfileImage", "Image cannot be null.");
                return View(user);
            }
            if (!file.CheckContentType())
            {
                ModelState.AddModelError("ProfileImage", "Only image files are allowed.");
                return View(user);
            }
            if (!file.CheckSize(500))
            {
                ModelState.AddModelError("ProfileImage", "The image size is too large. Maximum allowed size is 500KB.");
                return View(user);
            }

            var newUser = new AppUser
            {
                UserName = user.UserName,
                Email = user.Email,
                FullName = user.FullName,
                UserType = UserType.Admin,
                imageUrl = await file.SaveFile() // Save the new image file
            };

            var result = await _userManager.CreateAsync(newUser, user.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View(user);
            }

            await _userManager.AddToRoleAsync(newUser, "Admin");
            TempData["Success"] = "User created successfully!";
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Detail(string? id)
        {
            if (id == null) return BadRequest();
            var teacher = await _userManager.FindByIdAsync(id);
            if (teacher == null) return NotFound();

            return View(teacher);
        }
        public IActionResult Delete()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Delete(string? id)
        {
            if (id is null) return BadRequest();
            var admin = await _userManager.FindByIdAsync(id);
            if (admin is null) return NotFound();
            var result = await _userManager.DeleteAsync(admin);
            admin.imageUrl?.DeleteFile();

            if (result.Succeeded)
            {
                TempData["Success"] = "admin deleted successfully!";
                return RedirectToAction(nameof(Index));
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return RedirectToAction(nameof(Index));
        }
        [Area("SuperAdmin")]
        public async Task<IActionResult> Update(string id)
        {
            var existedUser = await _userManager.FindByIdAsync(id);
            if (existedUser is null)
            {
                return NotFound();
            }

            var userVm = new AppUserAdminUpdateVM
            {
                UserName = existedUser.UserName,
                Email = existedUser.Email,
                FullName = existedUser.FullName,

            };

            return View(userVm);
        }

        [HttpPost]
        [Area("SuperAdmin")]
        public async Task<IActionResult> Update(string id, AppUserAdminUpdateVM user )
        {
            if (ModelState.IsValid)
            {
                var existedUser = await _userManager.FindByIdAsync(id);
                if (existedUser is null)
                {
                    return NotFound();
                }
                var newProfileImage=user.ProfileImage;
                existedUser.UserName = user.UserName;
                existedUser.Email = user.Email;
                existedUser.FullName = user.FullName;
                if (newProfileImage != null)
                {
                    if (!newProfileImage.CheckContentType())
                    {
                        ModelState.AddModelError("ProfileImage", "Only image files are allowed.");
                        return View(user);
                    }
                    if (!newProfileImage.CheckSize(500))
                    {
                        ModelState.AddModelError("ProfileImage", "The image size is too large. Maximum allowed size is 500KB.");
                        return View(user);
                    }

                    // Delete the old image file
                    existedUser.imageUrl?.DeleteFile();

                    // Save the new image file
                    existedUser.imageUrl = await newProfileImage.SaveFile();
                }



                // Handle image upload if any

                IdentityResult result = await _userManager.UpdateAsync(existedUser);

                if (result.Succeeded)
                {
                    TempData["Success"] = "Admin updated successfully!";
                    return RedirectToAction(nameof(Index));
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(user);
        }

    }
}
