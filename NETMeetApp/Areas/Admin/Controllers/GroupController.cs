using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NETMeetApp.Enums;
using NETMeetApp.Models;

namespace NETMeetApp.Areas.Admin.Controllers
{
    [Authorize(Roles = "SuperAdmin,Admin")]
    [Area("Admin")]
    public class GroupController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public GroupController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var existUser = await _userManager.GetUserAsync(User);
            ViewBag.User = existUser;

            // Retrieve all unique group names
            var groupNames = _userManager.Users
                .Where(u => u.GroupName != null)
                .Select(u => u.GroupName)
                .Distinct()
                .ToList();

            return View(groupNames);
        }

        public async Task<IActionResult> Detail(string groupName)
        {
            var existUser = await _userManager.GetUserAsync(User);
            ViewBag.User = existUser;

            if (string.IsNullOrEmpty(groupName))
            {
                return BadRequest();
            }

            // Retrieve students with the specified group name
            var students = _userManager.Users
                .Where(u => u.GroupName == groupName && u.UserType == UserType.Student)
                .ToList();

            if (students.Count == 0)
            {
                return NotFound();
            }

            ViewBag.GroupName = groupName;
            return View(students);
        }
       
    }
}
