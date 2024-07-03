using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NETMeetApp.DAL;
using NETMeetApp.Extensions;
using NETMeetApp.Models;
using NETMeetApp.ViewModels.HomeWork;

namespace NETMeetApp.Controllers
{
    public class HomeWorkController : Controller
    {
        private readonly NetMeetAppDbContext _context;
        public HomeWorkController(NetMeetAppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public  async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return BadRequest();
            HomeWork homeWork=_context.Homeworks.AsNoTracking().FirstOrDefault(s=>s.Id==id);
            if (homeWork == null) return NotFound();
            return View(homeWork);
        }
        public async Task<IActionResult> UploadingFile(int? id,UploadFileVM uploadFileVM)
        {
            if(id is null) return BadRequest();
            if(!ModelState.IsValid) return View(uploadFileVM);
            var file=uploadFileVM.formFile;
            if (file == null)
            {

                ModelState.AddModelError("FilePath", "Image cannot be null.");
                return View(uploadFileVM);
            }
            HomeWork homeWork = new();
            homeWork.FilePath = await file.SaveFile();
            return View(homeWork);




        }
    }
}
