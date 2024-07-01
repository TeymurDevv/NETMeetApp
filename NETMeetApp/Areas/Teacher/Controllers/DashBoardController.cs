using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NETMeetApp.Enums;
using NETMeetApp.Models;

namespace NETMeetApp.Areas.Teacher.Controllers
{
    [Authorize(Roles = "SuperAdmin")]
    [Area("Teacher")]
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
            ICollection<AppUser> students = _userManager.Users.Where(s => s.UserType == UserType.Student).ToList();
            return View(students);
        }
    }
}
