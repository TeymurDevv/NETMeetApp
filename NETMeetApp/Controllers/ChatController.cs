using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using NETMeetApp.Models;

namespace NETMeetApp.Controllers
{
    public class ChatController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IHubContext<ChatHub> _hubContext;

        public ChatController(UserManager<AppUser> userManager, IHubContext<ChatHub> hubContext)
        {
            _userManager = userManager;
            _hubContext = hubContext;
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
