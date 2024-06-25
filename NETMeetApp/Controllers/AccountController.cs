using Microsoft.AspNetCore.Mvc;

namespace NETMeetApp.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }
    }
}
