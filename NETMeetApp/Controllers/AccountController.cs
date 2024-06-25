using Microsoft.AspNetCore.Mvc;

namespace NETMeetApp.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
