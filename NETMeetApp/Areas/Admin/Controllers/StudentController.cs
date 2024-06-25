using Microsoft.AspNetCore.Mvc;

namespace NETMeetApp.Areas.Admin.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
