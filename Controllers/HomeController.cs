using InterviewBoard.Models;
using InterviewBoard.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace InterviewBoard.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SignInManager<UserAcc> _signInManager;
        private readonly UserManager<UserAcc> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        private readonly PostService _postService;
        private readonly AcceptService _acceptService;

        public HomeController(ILogger<HomeController> logger, UserManager<UserAcc> userManager, SignInManager<UserAcc> signInManager, RoleManager<IdentityRole> roleManager,PostService postService, AcceptService acceptService)
        {
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _postService = postService;
            _acceptService = acceptService;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Post> posts = await _postService.AllPosts();
            List<Accept> accepts = new List<Accept>();
            List<Post> Addit = new List<Post>();

            string userName = User.Identity.Name;
            string role = await ReturnRole();
            
            if (role == "seeker")
            {
                accepts = await _acceptService.AllAcceptsBasedUsername(userName);
                posts =  await _postService.AllPostForSeeker(accepts);
            }


            ViewBag.Posts = posts;
            ViewBag.Role = role;
            ViewBag.Name = await ReturnName();
            

            return View();

        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Authorize(Roles = "seeker")]
        public IActionResult Secret()
        {

            return View();
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
            await _signInManager.SignOutAsync();
            
            return RedirectToAction("Index");
        }


        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            var user = await _userManager.FindByNameAsync(username);
            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user, password, false,false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");

        }
        
        [HttpPost]
        public async Task<ActionResult> Register(string name,string password,string email,string roleName)
        {
            
            var user = new UserAcc { 
            
                NormalizedUserName = name,
                UserName = email,
                Email = email,
                Name = name
            };

            
            if (await _roleManager.FindByNameAsync(roleName) == null) 
            {
                IdentityResult CreateRole = await _roleManager.CreateAsync(new IdentityRole(roleName));
            }
            
            var result = await _userManager.CreateAsync(user, password);
            
            if (result.Succeeded)
            {
                var resultRole = await _userManager.AddToRoleAsync(user, roleName);

                var resultLog = await _signInManager.PasswordSignInAsync(user, password, false, false);
                    if (resultLog.Succeeded && resultRole.Succeeded)
                    {
                        
                        return RedirectToAction("Index");
                    }
                
            }

            return RedirectToAction("Login");

        }


        public async Task<string> ReturnRole()
        {
            string userName = User.Identity.Name;
            string Role = "";
            if (userName != null)
            {
                UserAcc currentUser = await _userManager.FindByNameAsync(userName);

                if (await _userManager.IsInRoleAsync(currentUser, "giver"))
                {
                    Role = "giver";
                }
                else
                {
                    Role = "seeker";
                }
            }



            return Role;

        }
        public async Task<string> ReturnName()
        {
            string userName = User.Identity.Name;
            string name = "";
            if (userName != null)
            {
                UserAcc currentUser = await _userManager.FindByNameAsync(userName);

                name = currentUser.Name;
            }



            return name;

        }

    }
}
