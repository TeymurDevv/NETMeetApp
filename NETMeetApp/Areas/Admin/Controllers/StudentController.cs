using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NETMeetApp.Enums;
using NETMeetApp.Models;
using NETMeetApp.ViewModels.Admin;

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
            AppUser newUser = new();
            newUser.UserName = appUserStudentVM.UserName;
            newUser.Email = appUserStudentVM.Email;
            newUser.FullName = appUserStudentVM.FullName;
            newUser.UserType = UserType.Student;

            IdentityResult result = await _userManager.CreateAsync(newUser,appUserStudentVM.Password);
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
                GroupName=existingUser.GroupName
              
              

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



                // Handle image upload if any

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

