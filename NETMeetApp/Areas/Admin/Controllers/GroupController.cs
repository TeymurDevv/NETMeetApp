using Microsoft.AspNetCore.Mvc;
using NETMeetApp.DAL;
using System.Text.RegularExpressions;

namespace NETMeetApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GroupController : Controller
    {
       
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> detail(int? id)
        {
            if (id == null) return BadRequest();
           return View();
            
        }
        public  IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult>   Create(Group group)
        {
            return  View(group);
        }
    }
}
