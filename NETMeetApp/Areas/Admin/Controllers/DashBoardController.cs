using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NETMeetApp.Models;

namespace NETMeetApp.Areas.Admin.Controllers
{
    [Authorize(Roles = "SuperAdmin,Admin")]
    [Area("Admin")]
    public class DashBoardController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public DashBoardController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.StudentsCount = _userManager.Users.Where(s => s.UserType == Enums.UserType.Student).Count();
            ViewBag.TeachersCount = _userManager.Users.Where(s => s.UserType == Enums.UserType.Teacher).Count();
            ViewBag.AdminCount = _userManager.Users.Where(s => s.UserType == Enums.UserType.Admin).Count();


            var users = _userManager.Users.ToList();
            return View(users);

        }
        public async Task<IActionResult> Detail(string? id)
        {
            if (id == null) return BadRequest();
            var student = await _userManager.FindByIdAsync(id);
            if (student == null) return NotFound();
            return View(student);
        }
    }
}
