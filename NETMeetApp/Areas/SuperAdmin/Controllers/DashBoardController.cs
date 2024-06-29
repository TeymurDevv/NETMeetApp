using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NETMeetApp.Enums;
using NETMeetApp.Models;
using NETMeetApp.ViewModels.Admin;
using NETMeetApp.ViewModels.SuperAdmin;

namespace NETMeetApp.Areas.SuperAdmin.Controllers
{
    public class DashBoardController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public DashBoardController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [Area("SuperAdmin")]
        public IActionResult Index()
        {
            var students = _userManager.Users.Where(s => s.UserType == UserType.Admin).ToList();
            return View(students);
        }
       
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(AppUserAdminCreateVM user)
        {
            if (ModelState.IsValid)
            {
                var newUser = new AppUser
                {
                    UserType = UserType.Admin,
                    UserName = user.UserName,
                    Email = user.Email,
                    FullName = user.FullName,
                    Age = null,
                    Grade = null

                };
                // Handle image upload

                IdentityResult result = await _userManager.CreateAsync(newUser, user.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(user);
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

        public async Task<IActionResult> Update(string id)
        {
            var existedUser = await _userManager.FindByIdAsync(id);
            if (existedUser is null)
            {
                return NotFound();
            }

            var userVm = new AppUserCreateVm
            {
                UserName = existedUser.UserName,
                Email = existedUser.Email,
                FullName = existedUser.FullName,

            };

            return View(userVm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(string id, AppUserCreateVm user)
        {
            if (ModelState.IsValid)
            {
                var existedUser = await _userManager.FindByIdAsync(id);
                if (existedUser is null)
                {
                    return NotFound();
                }

                existedUser.UserName = user.UserName;
                existedUser.Email = user.Email;
                existedUser.FullName = user.FullName;


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
