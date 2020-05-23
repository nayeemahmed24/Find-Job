using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AuthenticationService.UserInformation;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Model;
using Models.View_Model;

namespace WebServices.Controllers
{
    public class ApplyController : Controller
    {
        private readonly UserInfoService _userInfoService;
        private readonly ApplyService.ApplyService _applyService;
        private readonly PostService.PostService _postService;


        public ApplyController(PostService.PostService postService,UserInfoService userInfoService,ApplyService.ApplyService applyService)
        {
            _postService = postService;
            _applyService = applyService;
            _userInfoService = userInfoService;
        }
        [HttpGet]
        public async Task<IActionResult> Apply(int id)
        {
            var userInfo = await GetUserInfoDetailes();
            Apply ap = new Apply();
            ap.user = userInfo.user;
            ap.PostId = id;
            var response = await _applyService.Create(ap);
            if (response.Status == true) return Json(new {result = "OK"}); 
            return Json(new { result = "Not OK"});
        }

        public async Task<IActionResult> MyApplies()
        {
            await AssignViewBag();
            var userInfo = await GetUserInfoDetailes();
            var applies = await _applyService.FindApplyByUserAccout(userInfo.user);
            var posts = await _postService.FindPostByApplies(applies);
            ViewBag.Posts = posts;
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Applied(int id)
        {
            var applies = await _applyService.FindApplyByPostId(id);
            List<UserAccount> users = new List<UserAccount>();
            foreach (var apply in applies)
            {
                users.Add(apply.user);
            }

            await AssignViewBag();
            ViewBag.Users = users;  
            return View();
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