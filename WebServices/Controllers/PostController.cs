using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthenticationService.UserInformation;
using Microsoft.AspNetCore.Mvc;
using Models.Model;

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

        public IActionResult Create()
        {
            AssignViewBag();
            return View();
        }
        public IActionResult Edit()
        {
            AssignViewBag();
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(Post post)
        {
            var response =  await _postService.CreatePost(post);
            if (response.Status)
            {
                // My Posts
                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("SomethingWrong", "Home");
        }

        private async void AssignViewBag()
        {
            ViewBag.UserDetailes = await _userInfoService.GetUserDetailes(User.Identity.Name);
        }
    }
}