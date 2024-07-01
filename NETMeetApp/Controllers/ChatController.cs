using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NETMeetApp.Models;

namespace NETMeetApp.Controllers
{
    public class ChatController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public ChatController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult ChatBox()
        {
            ViewBag.Users = _userManager.Users.ToList<AppUser>();
            ViewBag.ExistUser = _userManager.GetUserAsync(User);
            return View();
        }
        public IActionResult VideoChat()
        {
            return View();
        }
    }
}
