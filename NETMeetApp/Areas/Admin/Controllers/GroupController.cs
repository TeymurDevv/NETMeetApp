using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NETMeetApp.Models;

namespace NETMeetApp.Areas.Admin.Controllers
{
    [Authorize(Roles = "SuperAdmin,Admin")]
    [Area("Admin")]
    public class GroupController : Controller
    {
        private readonly UserManager<AppUser> userManager;

        public GroupController(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }

        public IActionResult Index()
        {

            return View();
        }
        public async Task<IActionResult> detail(int? id)
        {
            if (id == null) return BadRequest();
            return View();

        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(int id)
        {
            return View();
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return BadRequest();
            return View();
        }
    }
}
