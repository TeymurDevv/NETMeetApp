﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NETMeetApp.Enums;
using NETMeetApp.Models;
using NETMeetApp.ViewModels.Admin;

namespace NETMeetApp.Areas.Admin.Controllers
{
    [Authorize(Roles = "SuperAdmin,Admin")]
    [Area("Admin")]
    public class TeacherController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        public TeacherController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var existUser = await _userManager.GetUserAsync(User);
            ViewBag.User = existUser;
            var teachers = _userManager.Users.Where(t => t.UserType == UserType.Teacher).ToList();
            return View(teachers);
        }
        public async Task<IActionResult> Detail(string? id)
        {
            var existUser = await _userManager.GetUserAsync(User);
            ViewBag.User = existUser;
            if (id == null) return BadRequest();
            var teacher = await _userManager.FindByIdAsync(id);
            if (teacher == null) return NotFound();
            return View(teacher);
        }
        public async Task<IActionResult> Create()
        {
            var existUser = await _userManager.GetUserAsync(User);
            ViewBag.User = existUser;
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(AppUserCreateVm user)
        {
            var existUser = await _userManager.GetUserAsync(User);
            ViewBag.User = existUser;
            if (ModelState.IsValid)
            {
                var newUser = new AppUser
                {
                    UserType = UserType.Teacher,
                    UserName = user.UserName,
                    Email = user.Email,
                    FullName = user.FullName,
                    Age = null,
                    Grade = null
                };

                IdentityResult result = await _userManager.CreateAsync(newUser, user.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(user);
        }
        public async Task<IActionResult> Delete(string? id)
        {
            if (id == null) return BadRequest();
            var teacher = await _userManager.FindByIdAsync(id);
            if (teacher == null) return NotFound();
            var result = await _userManager.DeleteAsync(teacher);
            if (result.Succeeded)
            {
                TempData["Success"] = "User deleted successfully!";
                return RedirectToAction(nameof(Index));
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(string id)
        {
            var existingUser = await _userManager.FindByIdAsync(id);
            if (existingUser == null)
            {
                return NotFound();
            }

            var userVm = new AppUserCreateVm
            {
                UserName = existingUser.UserName,
                Email = existingUser.Email,
                FullName = existingUser.FullName
            };

            return View(userVm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(string id, AppUserCreateVm user)
        {
            if (ModelState.IsValid)
            {
                var existingUser = await _userManager.FindByIdAsync(id);
                if (existingUser == null)
                {
                    return NotFound();
                }

                existingUser.UserName = user.UserName;
                existingUser.Email = user.Email;
                existingUser.FullName = user.FullName;

                IdentityResult result = await _userManager.UpdateAsync(existingUser);

                if (result.Succeeded)
                {
                    TempData["Success"] = "User updated successfully!";
                    return RedirectToAction(nameof(Index));
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(user);
        }
    }
}

