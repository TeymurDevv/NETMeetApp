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
        public async Task<IActionResult> detail(int? id)
        {
            if (id == null) return BadRequest();
            return View();

        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(TeacherAppUser teacher)
        {
            return View(teacher);

        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return BadRequest();
            return View();
        }
    }
}
