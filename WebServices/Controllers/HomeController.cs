using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ManagerService.Manager.AuthenticationManager.UserInfoManager;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models.Model;

namespace WebServices.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserInfoManager _userInfoManager;

        public HomeController(ILogger<HomeController> logger, UserInfoManager userInfoManager)
        {
            _logger = logger;
            _userInfoManager = userInfoManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        private void AssignViewBag()
        {
            ViewBag.UserDetailes = _userInfoManager.getUser(User.Identity.Name);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
