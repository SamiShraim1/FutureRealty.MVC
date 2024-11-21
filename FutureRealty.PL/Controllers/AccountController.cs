using FutureRealty.DAL.Models;
using FutureRealty.PL.Helpers;
using FutureRealty.PL.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using NuGet.Common;

namespace FutureRealty.PL.Controllers
{

    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;

        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterVM model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = model.UserName,
                    Email = model.Email
                };

                var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
                    var confirmEmailLink = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, token = token }, protocol: HttpContext.Request.Scheme);
                    var email = new Email()
                    {
                        Subject = "Confirm Email",
                        Receivers = model.Email,
                        Body = $"Please confirm your account by clicking the following link: {confirmEmailLink}"
                    };

                    EmailSettings.SendEmail(email);

                    TempData["Message"] = "Registration successful! Please check your email to confirm your account.";
                    return RedirectToAction(nameof(Login));
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(model);
        }

        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if (userId == null || token == null)
            {
                TempData["ErrorMessage"] = "Invalid email confirmation request. Please try again.";
                return RedirectToAction("Error", "Home");
            }

            var user = await userManager.FindByIdAsync(userId);
            if (user == null)
            {
                TempData["ErrorMessage"] = "User not found. Please verify the link or contact support.";
                return RedirectToAction("Error", "Home");
            }

            var result = await userManager.ConfirmEmailAsync(user, token);
            if (result.Succeeded)
            {
                TempData["SuccessMessage"] = "Your email has been confirmed successfully! You can now log in.";
                return RedirectToAction(nameof(Login));
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            TempData["ErrorMessage"] = "Email confirmation failed. The link may have expired or is invalid.";
            return RedirectToAction("Error", "Home");
        }




        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(model.Email);

                if (user is not null)
                {
                    var check = await userManager.CheckPasswordAsync(user, model.Password);

                    if (check)
                    {
                        var result = await signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);
                        if (result.Succeeded)
                        {
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            ModelState.AddModelError(string.Empty, "Login failed. Please try again.");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Incorrect password.");
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Email not found.");
                }
            }

            return View(model);
        }


        public IActionResult Forgotpassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SendResetPasswordUrl(ForgotpasswordVM model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(model.Email);

                if (user is not null)
                {
                    var token = await userManager.GeneratePasswordResetTokenAsync(user);
                    var resetPasswordUrl = Url.Action("ResetPassword", "Account", new { email = model.Email, token = token }, protocol: HttpContext.Request.Scheme);

                    var email = new Email()
                    {
                        Subject = "Reset Password",
                        Receivers = model.Email,
                        Body = $"Please reset your password by clicking on the following link: {resetPasswordUrl}"
                    };

                    EmailSettings.SendEmail(email);

                    TempData["Message"] = "A reset password link has been sent to your email.";
                    return RedirectToAction(nameof(Forgotpassword));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Email not found.");
                    return View("Forgotpassword", model);
                }
            }

            return View("Forgotpassword", model);
        }




        public IActionResult ResetPassword(string email, string token)
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ResetPasswordVM model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(model.Email);
                if (user is null)
                {
                    ModelState.AddModelError(string.Empty, "User not found.");
                    return View(model);
                }

                var result = await userManager.ResetPasswordAsync(user, model.Token, model.NewPassword);
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Login));
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(model);
        }

    }
}
