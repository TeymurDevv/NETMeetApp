using Microsoft.AspNetCore.Mvc;
using NETMeetApp.ViewModels.Account;

namespace NETMeetApp.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Register(RegisterVM registerVM)
        {
            return View();
        }
    }
}
