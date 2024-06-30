using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NETMeetApp.DAL;
using NETMeetApp.Enums;
using NETMeetApp.Models;

namespace NETMeetApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly NetMeetAppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public HomeController(NetMeetAppDbContext context, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;

        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> Test()
        {

            return Content("OK");
        }
        public async Task<IActionResult> SeedData()
        {
            foreach (var item in Enum.GetValues(typeof(UserType)))
            {
                await _roleManager.CreateAsync(new IdentityRole { Name = item.ToString() });
            }

            var adminUser = new AppUser() { Email = "info@meeting.az", FullName = "Super Admin", UserName = "SuperAdmin", UserType = UserType.SuperAdmin, };
            string password = "Raska2024!!";
            IdentityResult result = await _userManager.CreateAsync(adminUser, password);
            await _userManager.AddToRoleAsync(adminUser, "SuperAdmin");
            return Content("OK");
        }
    }
}
