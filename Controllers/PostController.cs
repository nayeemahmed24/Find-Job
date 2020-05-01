using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using InterviewBoard.Models;
using InterviewBoard.Service;
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
        private readonly PostService _postService;
        private readonly AcceptService _acceptService;
      

        public PostController( UserManager<UserAcc> userManager, ApplicationDbContext db,PostService postService, AcceptService acceptService)
        {
            _db = db;
            _userManager = userManager;
            _postService = postService;
            _acceptService = acceptService;

        }
        
        
        [Authorize(Roles = "malik")]
        public async Task<IActionResult> Create()
        {
            await AssignViewBag();
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
                await _postService.CreatePost(post);
            }
            

            return RedirectToAction("Index","Home");
        }


        [Authorize(Roles = "malik")]
        public async Task<IActionResult> MyPosts()
        {
            string userName = User.Identity.Name;
            
            UserAcc currentUser = await _userManager.FindByNameAsync(userName);
            IEnumerable<Post> posts = await _postService.AllPostsWithUser(currentUser);
            
            ViewBag.Posts = posts;
            await AssignViewBag();
            
            return View();
        }

        
        
        #region Edit

        [Authorize(Roles = "malik")]
        public async Task<IActionResult> Edit(int id)
        {
            Post Post = await _postService.FindPostWithId(id);
            ViewBag.Post = Post;
            return View();
        }

        [Authorize(Roles = "malik")]
        [HttpPost]
        public async Task<IActionResult> Edit(Post post)
        {
            await _postService.EditPost(post);
            return RedirectToAction("MyPosts");
        }



        #endregion



        [Authorize(Roles = "malik")]
        public async Task<IActionResult> Delete(int id)
        {
            await _postService.DeletePost(id);
            return RedirectToAction("MyPosts");
        }

        public async Task<IActionResult> Applied(int id)
        {
            await AssignViewBag();
            List<Accept> accepts =  await _acceptService.AllAcceptBasedOnPostId(id);
            List<UserAcc> Users = new List<UserAcc>();
            foreach (var accept in accepts)
            {
                UserAcc us = await _userManager.FindByNameAsync(accept.Username);
                Users.Add(us);

            }
            ViewBag.Users = Users;
            return View();
        }

        [Authorize(Roles = "golam")]
        public async Task<IActionResult> MyInterviews()
        {

            string userName = User.Identity.Name;
            if (userName != null)
            {
                
                List<Accept> accepts = await _acceptService.AllAcceptsBasedUsername(userName);
                List<Post> posts = new List<Post>();
                foreach (var accept in accepts)
                {

                    Post p = await _postService.FindPostWithId(accept.PostId);
                    posts.Add(p);
                }
                ViewBag.Posts = posts;
            }

            await AssignViewBag();
            
            return View();
        }

        #region Applied

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
                return Json(new { result = "OK" });
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
            return Json(new { result = await Status(id) });
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

        #endregion


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

        public async Task AssignViewBag()
        {
            ViewBag.Role = await ReturnRole();
            ViewBag.Name = await ReturnName();
        }

    }
}