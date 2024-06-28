using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NETMeetApp.DAL;
using NETMeetApp.Models;

namespace NETMeetApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly NetMeetAppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public HomeController(NetMeetAppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> Test()
        {

            return Content("OK");
        }
    }
}
