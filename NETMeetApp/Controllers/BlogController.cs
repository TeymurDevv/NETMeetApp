﻿using Microsoft.AspNetCore.Mvc;

namespace NETMeetApp.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
