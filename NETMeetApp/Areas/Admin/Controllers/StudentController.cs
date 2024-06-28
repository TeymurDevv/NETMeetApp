using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NETMeetApp.Enums;
using NETMeetApp.Models;
using NETMeetApp.ViewModels.Admin;

namespace NETMeetApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StudentController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        public StudentController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            var students = _userManager.Users.Where(s => s.UserType == UserType.Student).ToList();
            return View(students);
        }
        public async Task<IActionResult> Detail(string? id)
        {
            if (id == null) return BadRequest();
            var student = await _userManager.FindByIdAsync(id);
            if (student == null) return NotFound();
            return View(student);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(AppUserCreateVm user)
        {
            if (ModelState.IsValid)
            {
                var newUser = new AppUser
                {
                    UserType = UserType.Student,
                    UserName = user.UserName,
                    Email = user.Email,
                    FullName = user.FullName,
                    Age =null,
                    Grade=null

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
        public async Task<IActionResult> Delete(string? id)
        {
            if (id == null) return BadRequest();
            var student=await _userManager.FindByIdAsync(id);
            if (student == null) return NotFound();
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

    }




}

