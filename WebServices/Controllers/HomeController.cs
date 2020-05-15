using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AuthenticationService.UserInformation;
using ManagerService.Manager.AuthenticationManager.UserInfoManager;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models.Model;

namespace WebServices.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserInfoService _userInfoService;

        public HomeController(ILogger<HomeController> logger, UserInfoService userInfoService)
        {
            _logger = logger;
            _userInfoService = userInfoService;
        }

        public IActionResult Index()
        {
            AssignViewBag();
            return View();
        }

        public IActionResult SomethingWrong()
        {
            return View();
        }

        private async void AssignViewBag()
        {
            ViewBag.UserDetailes = await _userInfoService.GetUserDetailes(User.Identity.Name);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
