using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NETMeetApp.DAL;
using NETMeetApp.Models;

namespace NETMeetApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly NetMeetAppStudentDbContext _context;
        private readonly UserManager<StudentAppUser> _userManager;

        public HomeController(NetMeetAppStudentDbContext context, UserManager<StudentAppUser> userManager)
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
            var student = new StudentAppUser
            {
                Country = "YARRRAK",
                FullName = "YRAKKKRASKDAD",
                imageUrl = "yasojdsaoijd",
                UserName = "student@example.com",
                Email = "student@example.com",
                Grade = 10,
                BioGraphy = "AISODJASOIJD",
            };

            var result = await _userManager.CreateAsync(student, "Password123!");
            return Content("OK");
        }
    }
}
