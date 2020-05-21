using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthenticationService.UserInformation;
using Microsoft.AspNetCore.Mvc;
using Models.Model;
using Models.View_Model;

namespace WebServices.Controllers
{
    public class PostController : Controller
    {
        private readonly PostService.PostService _postService;
        private readonly UserInfoService _userInfoService;

        public PostController(PostService.PostService postService,UserInfoService userInfoService)
        {
            _postService = postService;
            _userInfoService = userInfoService;
        }

        public async Task<IActionResult> Index()
        {
            await AssignViewBag();
            UserInfo userInfo = await GetUserInfoDetailes();
            var posts = await _postService.AllPosts(userInfo);
            ViewBag.Posts = posts;
            return View();
        }

        public async Task<IActionResult> Create()
        {
            await AssignViewBag();
            return View();
        }

        public async Task<IActionResult> MyPosts()
        {
            
            await AssignViewBag();
            var user = await GetUserInfoDetailes();
            List<Post> posts = await _postService.FindPostByUsername(user.user);
            ViewBag.Posts = posts;
            return View();
        }
        
        
        public async Task<IActionResult> Edit(int id)
        {
            await AssignViewBag();
            Post Post = await _postService.FindPostById(id);
            ViewBag.Post = Post;
            return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            var response = await _postService.DeletePost(id);
            if (response.Status) return RedirectToAction("MyPosts");
            return RedirectToAction("SomethingWrong", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Post post)
        {
            var response = await _postService.EditPost(post,new Post());
            if (response.Status) return RedirectToAction("MyPosts");
            return RedirectToAction("SomethingWrong","Home");
        }


        [HttpPost]
        public async Task<IActionResult> Create(Post post)
        {
            var user = await GetUserInfoDetailes();
            post.user = user.user;
            var response =  await _postService.CreatePost(post);
            if (response.Status)
            {
                return RedirectToAction("MyPosts");
            }

            return RedirectToAction("SomethingWrong", "Home");
        }


        private async Task AssignViewBag()
        {
            var detailes = await GetUserInfoDetailes();
            ViewBag.Name = detailes.user.Name;
            ViewBag.Role = detailes.roleName;
        }

        private async Task<UserInfo> GetUserInfoDetailes()
        {
            return await _userInfoService.GetUserDetailes(User.Identity.Name);
        }
    }
}