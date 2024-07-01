using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NETMeetApp.DAL;
using NETMeetApp.Models;
using NETMeetApp.ViewModels.Profile;

namespace NETMeetApp.Controllers
{
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly NetMeetAppDbContext _context;
        public ProfileController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, NetMeetAppDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user is null) return RedirectToAction("Index", "Home");
            return View(user);
        }

        public async Task<IActionResult> UserProfile(string? username)
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
            ProfileUpdateVM profileUpdateVM = new();

            profileUpdateVM.FullName = user.FullName;
            profileUpdateVM.Grade = user.Grade;
            profileUpdateVM.Country = user.Country;
            profileUpdateVM.Biography = user.BioGraphy;
            profileUpdateVM.Age = user.Age;

            return View(profileUpdateVM);
        }
        [HttpPost]
        public async Task<IActionResult> Update(ProfileUpdateVM profileUpdateVM)
        {
            if (!ModelState.IsValid)
            {
                return View(profileUpdateVM);
            }
            var file = profileUpdateVM.ProfileImage;
            if (file is null)
            {
                ModelState.AddModelError("ProfileImage", "Image can not be empty.");
                return View(profileUpdateVM);
            }
            if (!file.ContentType.Contains("image/"))
            {
                ModelState.AddModelError("ProfileImage", "The extension must be an image extension only.");
                return View(profileUpdateVM);
            }
            if (file.Length / 1024 > 500)
            {
                ModelState.AddModelError("ProfileImage", "The image's size is too long.");
                return View(profileUpdateVM);
            }
            var user = await _userManager.GetUserAsync(User);
            if (user is null) return RedirectToAction("Index", "Home");

            string fileName = Guid.NewGuid().ToString() + file.FileName;
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", fileName);

            using (FileStream fileStream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }

            // Updating the properties
            user.Grade = profileUpdateVM.Grade;
            user.Country = profileUpdateVM.Country;
            user.BioGraphy = profileUpdateVM.Biography;
            user.Age = profileUpdateVM.Age;
            user.FullName = profileUpdateVM.FullName;
            user.imageUrl = fileName;

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

        public async Task<IActionResult> GroupHomeworks(string groupName)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return RedirectToAction("Index", "Home");

            if (string.IsNullOrEmpty(groupName))
            {
                return BadRequest();
            }

            var homeworks = _context.Homeworks
                .Where(h => h.GroupName == groupName)
                .ToList();

            if (homeworks.Count == 0)
            {
                return NotFound();
            }

            ViewBag.GroupName = groupName;
            return View(homeworks);
        }
    }
}
