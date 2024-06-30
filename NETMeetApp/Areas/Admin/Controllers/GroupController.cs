using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
            return View();
        }
        public async Task<IActionResult> Detail(int? id)
        {
            var existUser = await _userManager.GetUserAsync(User);
            ViewBag.User = existUser;
            if (id == null) return BadRequest();
            return View();

        }
        public async Task<IActionResult> Create()
        {
            var existUser = await _userManager.GetUserAsync(User);
            ViewBag.User = existUser;
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(int id)
        {
            var existUser = await _userManager.GetUserAsync(User);
            ViewBag.User = existUser;
            return View();
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return BadRequest();
            return View();
        }
    }
}
