using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NETMeetApp.Models;

namespace NETMeetApp.Controllers
{
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public ProfileController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user is null) return RedirectToAction("Index", "Home");
            return View(user);
        }

        public async Task<IActionResult> UserName(string? username)
        {
            if (username is null) return RedirectToAction("Index", "Home");
            var user = await _userManager.FindByNameAsync(username);
            if (user is null) return RedirectToAction("Index", "Home");
            return View(user);


        }
    }
}
