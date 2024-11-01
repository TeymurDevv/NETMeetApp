using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NETMeetApp.DAL;
using NETMeetApp.Extensions;
using NETMeetApp.Models;
using NETMeetApp.ViewModels.Admin;
using NETMeetApp.ViewModels.HomeWork;

namespace NETMeetApp.Areas.Admin.Controllers
{
    [Authorize(Roles = "SuperAdmin,Admin")]
    [Area("Admin")]
    public class HomeWorkController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly NetMeetAppDbContext netMeetAppDbContext;

        public HomeWorkController(UserManager<AppUser> userManager, NetMeetAppDbContext _netMeetAppDbContext)
        {
            _userManager = userManager;
            netMeetAppDbContext = _netMeetAppDbContext;
        }
        public async Task<IActionResult> Index()
        {
            var existUser = await _userManager.GetUserAsync(User);
            ViewBag.User = existUser;
            var homeworks = netMeetAppDbContext.Homeworks.AsNoTracking().ToList();
            return View(homeworks);
        }
        [Area("Admin")]

        public async Task<IActionResult> Detail(int? id)
        {

            var existUser = await _userManager.GetUserAsync(User);
            ViewBag.User = existUser;
            if (id == null) return BadRequest();
            var homework = netMeetAppDbContext.Homeworks.AsNoTracking().FirstOrDefault(s => s.Id == id);
            if (homework == null) return NotFound();
            return View(homework);

        }
        public async Task<IActionResult> Create()
        {
            var existUser = await _userManager.GetUserAsync(User);
            ViewBag.User = existUser;
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(HomeWorkCreateVM homeWorkCreateVM)
        {
            var existUser = await _userManager.GetUserAsync(User);
            ViewBag.User = existUser;
            if (!ModelState.IsValid) return View(homeWorkCreateVM);

            HomeWork homeWork = new();
            homeWork.Title = homeWorkCreateVM.Title;
            homeWork.Description = homeWorkCreateVM.Description;
            homeWork.GroupName = homeWorkCreateVM.GroupName;
            netMeetAppDbContext.Homeworks.Add(homeWork);
            await netMeetAppDbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            var existUser = await _userManager.GetUserAsync(User);
            ViewBag.User = existUser;
            if (id == null) return BadRequest();
            var homework = await netMeetAppDbContext.Homeworks.FirstOrDefaultAsync(x => x.Id == id);
            if (homework == null) return NotFound();
            netMeetAppDbContext.Homeworks.Remove(homework);
            await netMeetAppDbContext.SaveChangesAsync();
            TempData["Success"] = "Homework deleted successfully!";
            return RedirectToAction(nameof(Index));
        }
        [Area("Admin")]
        public async Task<IActionResult> Update()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Update(int id, HomeWorkUpdateVM vm)
        {
            // Get the current user
            var existUser = await _userManager.GetUserAsync(User);
            ViewBag.User = existUser;

           
            if (!ModelState.IsValid) return View(vm);
            var existedHomeWork = await netMeetAppDbContext.Homeworks.FirstOrDefaultAsync(x => x.Id == id);
            if (existedHomeWork == null) return NotFound();

            existedHomeWork.Title = vm.Title;
            existedHomeWork.Description = vm.Description;
            existedHomeWork.GroupName = vm.GroupName;
            await netMeetAppDbContext.SaveChangesAsync();
            return RedirectToAction("Index"); 
        }

    }
}
