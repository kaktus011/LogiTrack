﻿using LogiTrack.Core.Contracts;
using LogiTrack.Core.Services;
using LogiTrack.Core.ViewModels.Home;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using static LogiTrack.Core.Constants.MessageConstants.ErrorMessages;
using static LogiTrack.Core.Constants.UserRolesConstants;

namespace LogiTrack.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IHomeService homeService;
        private readonly IUserService userService;

        public HomeController(ILogger<HomeController> logger, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager, IHomeService homeService, IUserService userService)
        {
            this.logger = logger;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
            this.homeService = homeService;
            this.userService = userService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            var model = new LoginViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            var user = await homeService.GetUserByEmailAsync(model.Email);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, InvalidEmailErrorMessage);
                return View(model);
            }
            var passwordCheck = await userManager.CheckPasswordAsync(user, model.Password);
            if (passwordCheck == false)
            {
                ModelState.AddModelError(string.Empty, InvalidLoginAttemptErrorMessage);
                return View(model);
            }
            var result = await signInManager.PasswordSignInAsync(user, model.Password, false, false);
            if (result.Succeeded == false)
            {
                ModelState.AddModelError(string.Empty, InvalidLoginAttemptErrorMessage);
                return View(model);
            }
            if(await userManager.IsInRoleAsync(user, ClientCompany))
            {
                return RedirectToAction("Dashboard", "Clients");
            }
            else if (await userManager.IsInRoleAsync(user, Logistics))
            {
                return RedirectToAction("Dashboard", "Logistics");
            }
            else if (await userManager.IsInRoleAsync(user, Accountant))
            {
                return RedirectToAction("Dashboard", "Accountant");
            }
            else if (await userManager.IsInRoleAsync(user, Speditor))
            {
                return RedirectToAction("Dashboard", "Speditor");
            }
            else if (await userManager.IsInRoleAsync(user, Driver))
            {
                return RedirectToAction("Dashboard", "Driver");
            }

            ModelState.AddModelError(string.Empty, InvalidLoginAttemptErrorMessage);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }

        [HttpGet]
        public async Task<IActionResult> Notifications()
        {
            //var username = User.GetUsername();
            var username = "logistics";
            if (await userService.LogisticsUserWithUsernameExistsAsync(username) == false)
            {
                return BadRequest("Not found");
            }
            var model = await userService.GetNotificationsForUserAsync(username);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> MarkAsRead(int id)
        {
            //var username = User.GetUsername();
            var username = "logistics";
            if (await userService.LogisticsUserWithUsernameExistsAsync(username) == false)
            {
                return BadRequest("Not found");
            }
            if(await userService.NotificationWithIdExistsForUserAsync(id, username) == false)
            {
                return Unauthorized();
            }
            if(await homeService.NotificationWithIdExistsdAsync(id) == false)
            {
                return BadRequest();
            }
            await homeService.MarkNotificationAsReadAsync(id);
            return RedirectToAction(nameof(Notifications));
        }
    }
}
