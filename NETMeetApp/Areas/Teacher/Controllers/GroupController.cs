using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NETMeetApp.DAL;
using NETMeetApp.Enums;
using NETMeetApp.Models;

namespace NETMeetApp.Areas.Teacher.Controllers
{
    [Authorize(Roles = "SuperAdmin,Admin")]
    [Area("Teacher")]
    public class GroupController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly NetMeetAppDbContext _context;  // Add this to access the database

        public GroupController(UserManager<AppUser> userManager, NetMeetAppDbContext context)
        {
            _userManager = userManager;
            _context = context;
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

        public async Task<IActionResult> Detail(string? groupName)
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

        public async Task<IActionResult> DetailHomework(string? groupName)
        {
            var existUser = await _userManager.GetUserAsync(User);
            ViewBag.User = existUser;

            if (string.IsNullOrEmpty(groupName))
            {
                return BadRequest();
            }

            // Retrieve homeworks with the specified group name
            var homeworks = _context.Homeworks
                .Where(h => h.GroupName == groupName)
                .ToList();
            if(homeworks is null)  return NotFound();

            if (homeworks.Count == 0)
            {
                return Content("there is no homework in this group");
            }

            ViewBag.GroupName = groupName;
          
            return View(homeworks);
        }
        [HttpPost]
        [Authorize(Roles = "SuperAdmin,Admin")]
        [ValidateAntiForgeryToken]
        public IActionResult Ban()
        {
            return View();
        }
        public async Task<IActionResult> Ban(string id)
        {
            var existUser = await _userManager.GetUserAsync(User);
            ViewBag.User = existUser;

            if (id == null)
            {
                return BadRequest();
            }

            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            user.IsBanned = true; // Mark user as banned

            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return RedirectToAction(nameof(Index));
            }

            TempData["Success"] = "User banned successfully!";

            // Pass the userName to the view
            ViewBag.BannedUserName = user.UserName;

            return View("BanNotice", user); // Change the view name to your ban notice view name
        }

    }
}
