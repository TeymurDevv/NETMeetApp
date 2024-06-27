using Microsoft.AspNetCore.Mvc;

namespace NETMeetApp.Controllers
{
    public class ChatController : Controller
    {
        public IActionResult ChatBox()
        {
            return View();
        }
        public IActionResult VideoChat()
        {
            return View();
        }
    }
}
