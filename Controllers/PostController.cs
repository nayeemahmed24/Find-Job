using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using InterviewBoard.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InterviewBoard.Controllers
{
    public class PostController : Controller
    {
        private readonly UserManager<UserAcc> _userManager;
        private readonly ApplicationDbContext _db;
      

        public PostController( UserManager<UserAcc> userManager, ApplicationDbContext db)
        {
            _db = db;
            _userManager = userManager;
                     
        }
        
        
        [Authorize(Roles = "malik")]
        public async Task<IActionResult> Create()
        {
            ViewBag.Role = await ReturnRole();
            ViewBag.Name = await ReturnName();
            return View();
        }
        
        
        [Authorize(Roles= "malik")]
        [HttpPost]
        public async Task<IActionResult> Create(Post post)
        {
            string userName = User.Identity.Name;
            if (userName != null)
            {
                UserAcc currentUser = await _userManager.FindByNameAsync(userName);
                post.user = currentUser;
                post.Username = currentUser.UserName;
                await _db.Post.AddAsync(post);
                await _db.SaveChangesAsync();
            }
            

            return RedirectToAction("Index","Home");
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
            ViewBag.Name = await ReturnName();
            ViewBag.Role = await ReturnRole();
            return View();
        }

        
        
        [Authorize(Roles = "malik")]
        public async Task<IActionResult> MyPosts()
        {
            string userName = User.Identity.Name;
            if (userName != null)
            {
                UserAcc currentUser = await _userManager.FindByNameAsync(userName);
                IEnumerable<Post> posts = await _db.Post.Where(d => d.user == currentUser).ToListAsync();
                ViewBag.Posts = posts;
            }

            ViewBag.Role = await ReturnRole();
            ViewBag.Name = await ReturnName();
            return View();
        }

        
        
        #region Edit

        [Authorize(Roles = "malik")]
        public async Task<IActionResult> Edit(int id)
        {
            Post Post = await _db.Post.Where(d => d.PostId == id).SingleAsync();
            ViewBag.Post = Post;
            return View();
        }
        [Authorize(Roles = "malik")]
        [HttpPost]
        public async Task<IActionResult> Edit(Post post)
        {
            var postE = await _db.Post.Where(d => d.PostId == post.PostId).SingleAsync();
            postE.Title = post.Title;
            postE.Content = post.Content;

            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }



        #endregion



        [Authorize(Roles = "malik")]
        public async Task<IActionResult> Delete(int id)
        {
            Post post = await _db.Post.Where(s => s.PostId == id).SingleAsync();
            var result = _db.Post.Remove(post);
            await _db.SaveChangesAsync();
            return RedirectToAction("MyPosts");
        }

        
        [HttpGet]
        [Authorize(Roles = "golam")]
        public async Task<IActionResult> Apply(int id)
        {
            Accept accept = new Accept();
            if (await Status(id) == "OK")
            {
                Post post = await _db.Post.Where(s => s.PostId == id).SingleAsync();
                accept.PostId = post.PostId;
                accept.user = await _userManager.FindByNameAsync(User.Identity.Name);
                accept.Username = accept.user.UserName;
                await _db.Accept.AddAsync(accept);
                await _db.SaveChangesAsync();
                return Json(new {result = "OK"});
            }
            else
            {
                // Error
                return Json(new { result = "Sry" });
            }

        }

        [HttpGet]
        [Authorize(Roles = "golam")]
        public async Task<IActionResult> ApplyStatus(int id)
        {
            return Json(new {result = await Status(id)});
        }
        [Authorize(Roles = "golam")]
        public async Task<IActionResult> MyInterviews()
        {

            string userName = User.Identity.Name;
            if (userName != null)
            {
                UserAcc currentUser = await _userManager.FindByNameAsync(userName);
                IEnumerable<Accept> accepts = await _db.Accept.Where(d => d.user == currentUser).ToListAsync();
                
                List<Post> posts = new List<Post>();
                foreach (var accept in accepts)
                {
                    
                    Post p = await _db.Post.Where(d => d.PostId == accept.PostId).SingleAsync();
                    posts.Add(p);

                }
                ViewBag.Posts = posts;
            }

            ViewBag.Role = await ReturnRole();
            ViewBag.Name = await ReturnName();
            return View();
        }




        public async Task<String> Status(int id)
        {
            Post post = await _db.Post.Where(s => s.PostId == id).SingleAsync();
            string userName = User.Identity.Name;
            UserAcc currentUser = null;
            if (userName != null)
            {
                currentUser = await _userManager.FindByNameAsync(userName);
            }
            IEnumerable<Accept> check = await _db.Accept.Where(s => s.PostId == id && s.user == currentUser)
                .ToListAsync();
            
            string res;
            if (check.Count() == 0)
            {
                res = "OK";
            }
            else
            {
                res = "Sry";
            }

            return res;

        }

        public async Task<IActionResult> Applied(int id)
        {
            ViewBag.Role = await ReturnRole();
            ViewBag.Name = await ReturnName();
            List<Accept> accepts =  await _db.Accept.Where(d => d.PostId == id).ToListAsync();
            List<UserAcc> Users = new List<UserAcc>();
            foreach (var accept in accepts)
            {
                UserAcc us = await _userManager.FindByNameAsync(accept.Username);
                Users.Add(us);

            }
            ViewBag.Users = Users;
            return View();
        }

        #region ReturnRole
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

        #endregion


    }
}