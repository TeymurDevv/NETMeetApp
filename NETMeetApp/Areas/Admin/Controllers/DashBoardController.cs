using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            var existUser = await _userManager.GetUserAsync(User);
            ViewBag.User = existUser;
            ViewBag.StudentsCount = _userManager.Users.Where(s => s.UserType == Enums.UserType.Student).Count();
            ViewBag.TeachersCount = _userManager.Users.Where(s => s.UserType == Enums.UserType.Teacher).Count();
            ViewBag.AdminCount = _userManager.Users.Where(s => s.UserType == Enums.UserType.Admin).Count();
            ViewBag.SuperAdminCount=_userManager.Users.Where(s=>s.UserType==Enums.UserType.SuperAdmin).Count();



            var users = await _userManager.Users.ToListAsync();
            return View(users);

        }
        public async Task<IActionResult> Detail(string? id)
        {
            var existUser = await _userManager.GetUserAsync(User);
            ViewBag.User = existUser;
            if (id == null) return BadRequest();
            var student = await _userManager.FindByIdAsync(id);
            if (student == null) return NotFound();
            return View(student);
        }
    }
}
