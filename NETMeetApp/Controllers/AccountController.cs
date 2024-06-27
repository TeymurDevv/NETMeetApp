﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NETMeetApp.Models;
using NETMeetApp.ViewModels.Account;

namespace NETMeetApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<StudentAppUser> _userManager;
        private readonly SignInManager<StudentAppUser> _signInManager;

        public AccountController(UserManager<StudentAppUser> userManager, SignInManager<StudentAppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid) return View();
            StudentAppUser user = new();
            user.Email = registerVM.Email;
            user.FullName = registerVM.FullName;
            user.UserName = registerVM.UserName;


            IdentityResult result = await _userManager.CreateAsync(user, registerVM.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(registerVM);
            }
            await _signInManager.SignInAsync(user, isPersistent: false);
            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (!ModelState.IsValid) return View();
            var user = await _userManager.FindByNameAsync(loginVM.UserNameOrEmail);
            if (user is null) 
            {
                user = await _userManager.FindByEmailAsync(loginVM.UserNameOrEmail);
                if (user is null) 
                {
                    ModelState.AddModelError("", "User with this credentials not found.");
                    return View(loginVM);
                }
            }

            var result = await _signInManager.PasswordSignInAsync(user,loginVM.Password,loginVM.RememberMe,true);

            if (result.IsLockedOut)
            {
                ModelState.AddModelError("", "Your account is blocked.");
                return View(loginVM);
            }

            if (!result.Succeeded) 
            {
                ModelState.AddModelError("", "Something went wrong.");
                return View(loginVM);
            }

            await _signInManager.SignInAsync(user, loginVM.RememberMe);

            return RedirectToAction("Index", "Home");
        }
    }
}
