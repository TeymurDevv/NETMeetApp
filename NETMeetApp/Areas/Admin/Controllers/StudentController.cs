using Microsoft.AspNetCore.Mvc;

namespace NETMeetApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Detail(int? id)
        {
            if(id == null) return BadRequest();

            return View();
        }
    }
}
