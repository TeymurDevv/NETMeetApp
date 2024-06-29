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


    }
}
