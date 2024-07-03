using Microsoft.AspNetCore.Mvc;

namespace NETMeetApp.Controllers
{
    public class FaqController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
