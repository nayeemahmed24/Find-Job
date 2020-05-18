using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AuthenticationService;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace WebServices.Controllers
{
    public class AuthController : Controller
    {
        private readonly AuthenticatorService _userAuth;
        private readonly SignInManager<UserAccount> _signInManager;
        private readonly UserManager<UserAccount> _userManager;

        public AuthController(AuthenticatorService userAuth,UserManager<UserAccount> userManager, SignInManager<UserAccount> signInManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _userAuth = userAuth;
        }

        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            var result = await _userAuth.Logout();
            if (result.Status)
            {
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("SomethingWrong", "Home");

        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            //var response = await _userAuth.Login(username,password);
            var user = await _userManager.FindByNameAsync(username);
            if (user != null)
            {
                
                var result = await _signInManager.PasswordSignInAsync(user, password, true, false);
                Debug.Print(_signInManager.IsSignedIn(User) + "");
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("SomethingWrong", "Home");

        }

        [HttpPost]
        public async Task<ActionResult> Register(string name, string password, string email, string roleName)
        {
            var user = new UserAccount
            {
                NormalizedUserName = name,
                UserName = email,
                Email = email,
                Name = name
            };

            var response = await _userAuth.Register(user,password,roleName);
            
            if (response.Status)
            {
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("SomethingWrong", "Home");

        }
    }
}