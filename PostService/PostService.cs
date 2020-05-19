using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AuthenticationService.UserInformation;
using ManagerService.Manager.AuthenticationManager.UserInfoManager;
using ManagerService.Manager.PostManager;
using Models;
using Models.Model;

namespace PostService
{
    public class PostService : IPostService
    {
        private readonly PostManger _postManager;
        private readonly UserInfoService _userInfoService;
        public PostService(PostManger postManager,UserInfoService userInfoService)
        {
            _postManager = postManager;
            _userInfoService = userInfoService;
        }
        public async Task<Response> CreatePost(Post post,string username)
        {
            post.user =  await _userInfoService.GetUser(username);
            return await _postManager.Create(post);
        }

        public async Task<Response> EditPost(Post Newpost,Post PrevPost)
        {
            PrevPost = Newpost;
            return await _postManager.EditPost(Newpost, PrevPost);
        }

        public async Task<Response> DeletePost(int id)
        {
            Post post = await FindPostById(id);
            return await _postManager.DeletePost(post);
        }

        public async Task<Post> FindPostById(int id)
        {
            return await _postManager.SearchPostByPostId(id);
        }

       

        public async Task<List<Post>> FindPostByUsername(string username)
        {
            UserAccount user = await _userInfoService.GetUser(username);
            return await _postManager.SearchPostByUser(user);
        }
    }
}
