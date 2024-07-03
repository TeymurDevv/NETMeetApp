using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NETMeetApp.Models;
using NETMeetApp.ViewModels.Account;
using System.Net;
using System.Net.Mail;

namespace NETMeetApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
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
            AppUser user = new();
            user.Email = registerVM.Email;
            user.FullName = registerVM.FullName;
            user.UserName = registerVM.UserName;
            user.UserType = Enums.UserType.Student;
            user.Age = null;
            user.Grade = null;



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
            if (user.IsBanned == true)
            {
                ModelState.AddModelError("", "Your account has been banned.");
                return View(loginVM);
            }
            var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, loginVM.RememberMe, true);

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
        public IActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            AppUser user = await _userManager.FindByEmailAsync(email);

            if (user is null)
            {
                ModelState.AddModelError("Email", "Email is not available");
                return View();
            }

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            var link = Url.Action(nameof(ResetPassword), "Account",
                new { email = user.Email, token = token }, Request.Scheme, Request.Host.ToString());

            MailMessage mailMessage = new();

            mailMessage.From = new MailAddress("teymurns@code.edu.az", "Email From Bakalavr.az");
            mailMessage.To.Add(new MailAddress(user.Email));
            mailMessage.Subject = "Reset Password";

            mailMessage.Body = $"<a href={link}>Please click here for reset password</a>";
            mailMessage.IsBodyHtml = true;

            SmtpClient smtpClient = new();
            smtpClient.Host = "smtp.gmail.com";
            smtpClient.Port = 587;
            smtpClient.EnableSsl = true;

            smtpClient.Credentials = new NetworkCredential("teymurns@code.edu.az", "lsgy jgon moyd kfwd");
            smtpClient.Send(mailMessage);

            return RedirectToAction("Index", "Home");
        }
        public IActionResult ResetPassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ResetPassword(string email, string token, ResetPasswordVM resetPasswordVM)
        {
            AppUser appUser = await _userManager.FindByEmailAsync(email);
            if (!ModelState.IsValid) return View();

            await _userManager.ResetPasswordAsync(appUser, token, resetPasswordVM.Password);
            await _userManager.UpdateSecurityStampAsync(appUser);

            return RedirectToAction("Login", "Account");
        }
    }
}
