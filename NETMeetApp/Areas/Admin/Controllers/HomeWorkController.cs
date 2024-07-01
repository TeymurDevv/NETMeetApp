using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NETMeetApp.DAL;
using NETMeetApp.Models;

namespace NETMeetApp.Areas.Admin.Controllers
{
    [Authorize(Roles = "SuperAdmin,Admin")]
    [Area("Admin")]
    public class HomeWorkController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly NetMeetAppDbContext netMeetAppDbContext;

        public HomeWorkController(UserManager<AppUser> userManager,NetMeetAppDbContext _netMeetAppDbContext)
        {
            _userManager = userManager;
            netMeetAppDbContext = _netMeetAppDbContext;
        }
        public async Task<IActionResult> Index()
        {
            var existUser = await _userManager.GetUserAsync(User);
            ViewBag.User = existUser;
            var homeworks=netMeetAppDbContext.Homeworks.AsNoTracking().ToList();
            return View(homeworks);
        }
        [Area("Admin")]

        public async Task<IActionResult> Detail(int? id)
        {
            var existUser = await _userManager.GetUserAsync(User);
            ViewBag.User = existUser;
            if (id == null) return BadRequest(); 
            var homework=netMeetAppDbContext.Homeworks.AsNoTracking().FirstOrDefault(s=>s.Id==id);
            if (homework == null) return NotFound();
            return View(homework);

        }
        


    }
}
