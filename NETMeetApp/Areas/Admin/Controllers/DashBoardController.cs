using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NETMeetApp.Models;
using System.Threading.Tasks;

namespace NETMeetApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashBoardController : Controller
    {
        private readonly UserManager<AppUserUpdateVM> _userManager;

        public DashBoardController(UserManager<AppUserUpdateVM> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
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
