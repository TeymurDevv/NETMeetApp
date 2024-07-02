using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NETMeetApp.DAL;
using NETMeetApp.Models;

namespace NETMeetApp.Controllers
{
    public class HomeWorkController : Controller
    {
        private readonly NetMeetAppDbContext _context;
        public HomeWorkController(NetMeetAppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public  async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return BadRequest();
            HomeWork homeWork=_context.Homeworks.AsNoTracking().FirstOrDefault(s=>s.Id==id);
            if (homeWork == null) return NotFound();
            return View(homeWork);
        }
    }
}
