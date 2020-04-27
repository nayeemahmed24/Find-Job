using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using InterviewBoard.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace InterviewBoard.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SignInManager<UserAcc> _signInManager;
        private readonly UserManager<UserAcc> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _db;


        public HomeController(ApplicationDbContext db,ILogger<HomeController> logger, UserManager<UserAcc> userManager, SignInManager<UserAcc> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public async Task<IActionResult> Index()
        {

            string userName = User.Identity.Name;
            string role = "";
            if (userName != null)
            {
                UserAcc currentUser = await _userManager.FindByNameAsync(userName);
                if (await _userManager.IsInRoleAsync(currentUser, "golam"))
                {
                    role = "golam";
                }
            }
            IEnumerable<Post> posts = await _db.Post.ToListAsync();
            IEnumerable<Accept> accepts = new List<Accept>();
            List<Post> Addit = new List<Post>();
            if (role == "golam")
            {
                accepts = await _db.Accept.Where(d => d.Username == userName).ToListAsync();

                foreach (var post in posts)
                {
                    var flag = true;
                    foreach (var accept in accepts)
                    {
                        if (accept.PostId == post.PostId) flag = false;

                    }

                    if (flag == true)
                    {
                        Debug.Print("HIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIII");
                        // Addit.Append(post);
                        Addit.Add(post);
                    }
                }
                Debug.Print(Addit.Count() + "");
                posts = Addit;

            }


            ViewBag.Posts = posts;
            ViewBag.Role = await ReturnRole();
            ViewBag.Name = await ReturnName();
            

            return View();

        }

        public async Task<IActionResult> CreateChat(Messege messege)
        {
            var sender = await _userManager.GetUserAsync(User);
            // messege.SenderUser = sender.UserName;
            // messege.SenderUser = sender;
            await _db.Messege.AddAsync(messege);
            await _db.SaveChangesAsync();
            return Ok();
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

        [Authorize(Roles = "golam")]
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

                if (await _userManager.IsInRoleAsync(currentUser, "malik"))
                {
                    Role = "malik";
                }
                else
                {
                    Role = "golam";
                }
            }



            return Role;

        }
        public async Task<string> ReturnName()
        {
            string userName = User.Identity.Name;
            string Role = "";
            if (userName != null)
            {
                UserAcc currentUser = await _userManager.FindByNameAsync(userName);

                Role = currentUser.Name;
            }



            return Role;

        }

    }
}
