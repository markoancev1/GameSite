using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameSite.Logger;
using GameSite.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace GameSite.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger<AccountController> _logger;
        public AccountController(UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            ILogger<AccountController> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        [Authorize(Roles = "admin")]
        public IActionResult Index()
        {
            var users = _userManager.Users;
            if (users != null)
            {
                _logger.LogInformation(LoggerMessageDisplay.UsersListed);
            }
            else
            {
                _logger.LogInformation(LoggerMessageDisplay.NoUsersInDB);
            }
            return View(users);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    EmailConfirmed = true
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    _logger.LogInformation(LoggerMessageDisplay.RegisterUserModelStateValid);
                    return RedirectToAction("index", "home");
                }

              
            }
            else
            {
                _logger.LogWarning(LoggerMessageDisplay.RegisterUserModelStateValidError);
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(
                    model.Email, model.Password, model.RememberMe, false);

                if (result.Succeeded)
                {
                    _logger.LogInformation(LoggerMessageDisplay.LoginUserModelStateValid);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    _logger.LogWarning(LoggerMessageDisplay.LoginUserModelStateValidError);
                }
            }

            return View(model);
        }



        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation(LoggerMessageDisplay.LogoutUser);
            return RedirectToAction("index", "home");
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            try
            {
                

                var result = await _userManager.DeleteAsync(user);

                if (result.Succeeded)
                {
                    _logger.LogInformation(LoggerMessageDisplay.UserDeleted);
                    return RedirectToAction("Index");
                }
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError($"Exception Occured : {ex}");
                ViewBag.ErrorTitle = $"{user.Email} is in use";
                ViewBag.ErrorMessage = $"{user.Email} cannot be deleted. If you want to delete this user, please remove the users from the role";
                return View("Error");
            }
            return View("Index");
        }
    }

}

