using Microsoft.AspNetCore.Mvc;

namespace NETMeetApp.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
