using Microsoft.AspNetCore.Mvc;
using NETMeetApp.DAL;

namespace NETMeetApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly NETMeetAppDbContext _context;

        public HomeController(NETMeetAppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
