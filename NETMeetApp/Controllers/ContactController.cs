using Microsoft.AspNetCore.Mvc;

namespace NETMeetApp.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
