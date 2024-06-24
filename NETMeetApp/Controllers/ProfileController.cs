using Microsoft.AspNetCore.Mvc;

namespace NETMeetApp.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
