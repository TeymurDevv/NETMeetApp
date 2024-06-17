using Microsoft.AspNetCore.Mvc;

namespace NETMeetApp.Controllers
{
    public class MeetController : Controller
    {
        [Route("meet/{meetId}")]
        public IActionResult Index(string meetId)
        {
            ViewData["MeetingId"] = meetId;
            return View();
        }
    }
}
