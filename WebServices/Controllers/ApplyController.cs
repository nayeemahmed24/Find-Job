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
        public async Task<IActionResult> Apply(int id)
        {
            var userInfo = await GetUserInfoDetailes();
            var response = await _applyService.Create(new Apply(userInfo.user,id));
            if (response.Status == true) return Json(new {result = "OK"}); 
            return Json(new { result = "Not OK"});
        }

        public async Task<IActionResult> MyApplies()
        {
            await AssignViewBag();
            var userInfo = await GetUserInfoDetailes();
            var applies = await _applyService.FindApplyByUserAccout(userInfo.user);
            var posts = await _postService.FindPostByApplies(applies);
            ViewBag.Post = posts;
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