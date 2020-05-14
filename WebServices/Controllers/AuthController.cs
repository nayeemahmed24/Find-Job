using System;
using System.Collections.Generic;
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
        private readonly Authenticator _userAuth;
        public AuthController(Authenticator userAuth)
        {
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
            await _userAuth.Logout();
            return RedirectToAction("Index","Home");
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            var response = await _userAuth.Login(username,password);
            return RedirectToAction("Index", "Home");
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
            return RedirectToAction("Index", "Home");
        }
    }
}