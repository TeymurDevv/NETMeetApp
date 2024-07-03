using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NETMeetApp.Enums;
using NETMeetApp.Extensions;
using NETMeetApp.Models;
using NETMeetApp.ViewModels.Admin;
using NETMeetApp.ViewModels.Profile;

namespace NETMeetApp.Areas.Admin.Controllers
{
    [Authorize(Roles = "SuperAdmin,Admin")]
    [Area("Admin")]
    public class StudentController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        public StudentController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
        
            var existUser = await _userManager.GetUserAsync(User);
            ViewBag.User = existUser;
            ICollection<AppUser> students = _userManager.Users.Where(s => s.UserType == UserType.Student).ToList();
            return View(students);
        }
        public async Task<IActionResult> Detail(string? id)
        {
            var existUser = await _userManager.GetUserAsync(User);
            ViewBag.User = existUser;
            if (id is null) return BadRequest();
            AppUser? student = await _userManager.FindByIdAsync(id);
            if (student is null) return NotFound();
            return View(student);
        }
        public async Task<IActionResult> Create()
        {
            var existUser = await _userManager.GetUserAsync(User);
            ViewBag.User = existUser;
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(AppUserStudentVM appUserStudentVM)
        {
            var existUser = await _userManager.GetUserAsync(User);
            ViewBag.User = existUser;
            if (!ModelState.IsValid) return View(appUserStudentVM);

            var file = appUserStudentVM.ProfileImage;
            if (file == null)
            {
                ModelState.AddModelError("ProfileImage", "Image cannot be null.");
                return View(appUserStudentVM);
            }
            if (!file.CheckContentType())
            {
                ModelState.AddModelError("ProfileImage", "Only image files are allowed.");
                return View(appUserStudentVM);
            }
            if (!file.CheckSize(500))
            {
                ModelState.AddModelError("ProfileImage", "The image size is too large. Maximum allowed size is 500KB.");
                return View(appUserStudentVM);
            }



            AppUser newUser = new AppUser
            {
                UserName = appUserStudentVM.UserName,
                Email = appUserStudentVM.Email,
                FullName = appUserStudentVM.FullName,
                GroupName = appUserStudentVM.GroupName,
                UserType = UserType.Student,
                imageUrl = await file.SaveFile()   // Update with the saved file name
            }; 

            IdentityResult result = await _userManager.CreateAsync(newUser, appUserStudentVM.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View(appUserStudentVM);
            }

            await _userManager.AddToRoleAsync(newUser, "Student");
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(string? id)
        {
            var existUser = await _userManager.GetUserAsync(User);
            ViewBag.User = existUser;
            if (id is null) return BadRequest();
            var student = await _userManager.FindByIdAsync(id);
            if (student is null) return NotFound();
            var result = await _userManager.DeleteAsync(student);
            // Delete the user's profile image
            student.imageUrl?.DeleteFile();
            if (result.Succeeded)
            {
                TempData["Success"] = "User deleted successfully!";
                return RedirectToAction(nameof(Index));
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(string id)
        {
            var existUser = await _userManager.GetUserAsync(User);
            ViewBag.User = existUser;
            var existingUser = await _userManager.FindByIdAsync(id);
            if (existingUser is null)
            {
                return NotFound();
            }

            var userVm = new AppUserStudentUpdateVM
            {
                UserName = existingUser.UserName,
                Email = existingUser.Email,
                FullName = existingUser.FullName,
                GroupName = existingUser.GroupName
            };

            return View(userVm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(string id, AppUserStudentUpdateVM user)
        {
            var existUser = await _userManager.GetUserAsync(User);
            ViewBag.User = existUser;
            if (ModelState.IsValid)
            {
                var existingUser = await _userManager.FindByIdAsync(id);
                if (existingUser is null)
                {
                    return NotFound();
                }

                existingUser.UserName = user.UserName;
                existingUser.Email = user.Email;
                existingUser.FullName = user.FullName;
                existingUser.GroupName = user.GroupName;
                var newProfileImage = user.ProfileImage;

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

                    // Delete the old image file if it exists
                    if (!string.IsNullOrEmpty(existingUser.imageUrl))
                    {
                        existingUser.imageUrl.DeleteFile();
                    }

                    // Save the new image file
                    existingUser.imageUrl = await newProfileImage.SaveFile();
                }

                IdentityResult result = await _userManager.UpdateAsync(existingUser);

                if (result.Succeeded)
                {
                    TempData["Success"] = "User updated successfully!";
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

