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
    }
}
