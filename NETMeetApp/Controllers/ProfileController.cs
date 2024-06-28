using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NETMeetApp.Models;

namespace NETMeetApp.Controllers
{
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public ProfileController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
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
        public async Task<IActionResult> Update()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user is null) return RedirectToAction("Index", "Home");
            return View(user);
        }
        [HttpPost]
        public async Task<IActionResult> Update(AppUser appUser)
        {
            if (!ModelState.IsValid)
            {
                return View(appUser);
            }
            var user = await _userManager.GetUserAsync(User);
            if (user is null) return RedirectToAction("Index", "Home");

            // Updating the properties
            user.Grade = appUser.Grade;
            user.imageUrl = appUser.imageUrl;
            user.Country = appUser.Country;
            user.BioGraphy = appUser.BioGraphy;
            user.Age = appUser.Age;
            user.FullName = appUser.FullName;
            user.GroupId = appUser.GroupId;

            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                // Refresh the sign-in cookies to reflect changes
                await _signInManager.RefreshSignInAsync(user);
                return RedirectToAction("Index");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return View(user);
        }
    }
}
