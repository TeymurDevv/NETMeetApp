using Microsoft.AspNetCore.Mvc;

namespace NETMeetApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
