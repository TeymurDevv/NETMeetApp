using Microsoft.AspNetCore.Mvc;
using NETMeetApp.Models;

namespace NETMeetApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TeacherController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public async  Task<IActionResult> detail(int? id)
        {
            if (id == null) return BadRequest();
            return View();

        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Teacher teacher)
        {
            return View(teacher);

        }
    }
}
