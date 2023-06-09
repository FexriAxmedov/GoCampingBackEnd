﻿using GoCamping.DAL.DBModel;
using GoCamping.WebAdmin.Models;
using GoCamping.WebAdmin.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace GoCamping.WebAdmin.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private UserManager<AppUser> _userManager;
        private SignInManager<AppUser> _signInManager;

        public HomeController(ILogger<HomeController> logger, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Login(string ReturnUrl)
         {
            TempData["ReturnUrl"] = ReturnUrl;
            return View();
         }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                AppUser user = await _userManager.FindByEmailAsync(loginViewModel.Email);
                if (user != null)
                {
                    if (await _userManager.IsLockedOutAsync(user))
                    {
                        ModelState.AddModelError("", "Hesabınız bir süreliyine kilitlenmişdir. Lütfen daha sonra tekrar deneyiniz.");
                    }
                    else
                    {
                        await _signInManager.SignOutAsync();
                        Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, loginViewModel.RememberMe, false);

                        if (result.Succeeded)
                        {
                            await _userManager.ResetAccessFailedCountAsync(user);
                            if (TempData["ReturnUrl"] != null)
                            {
                                return Redirect(TempData["ReturnUrl"].ToString());
                            }
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {

                            await _userManager.AccessFailedAsync(user);

                            int fail = await _userManager.GetAccessFailedCountAsync(user);

                            ModelState.AddModelError("", $"{fail} kez başarısız giriş.");
                            if (fail == 3)
                            {
                                await _userManager.SetLockoutEndDateAsync(user, new DateTimeOffset(DateTime.Now.AddMinutes(20)));
                                ModelState.AddModelError("", "Hesabınız 3 başarısız girişten dolayı 20 dakika süreyle kilitlenmişdir. Lütfen daha sonra tekrar deneyiniz.");
                            }
                            else
                            {
                                ModelState.AddModelError("", "Email adresi veya şifresiniz yanlış.");
                            }
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Bu email adresine kayıtlı kullanıcı bulunamamıştır.");
                }

            }
            return View(loginViewModel);
        }








        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
