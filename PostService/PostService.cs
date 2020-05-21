using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthenticationService.UserInformation;
using ManagerService.Manager.AuthenticationManager.UserInfoManager;
using ManagerService.Manager.PostManager;
using Models;
using Models.Model;
using Models.View_Model;

namespace PostService
{
    public class PostService : IPostService
    {
        private readonly PostManger _postManager;
        
        private readonly ApplyService.ApplyService _applyService; 
        public PostService(PostManger postManager,ApplyService.ApplyService applyService)
        {
            _postManager = postManager;
            _applyService = applyService;
        }

        public async Task<List<Post>> AllPosts(UserInfo user)
        {
            List<Post> allPosts = await _postManager.AllPosts();
            List<Apply> applies = await _applyService.FindApplyByUserAccout(user.user);
            foreach (var apply in applies)
            {
                var itemToRemove = allPosts.Single(r => r.PostId == apply.PostId);
                allPosts.Remove(itemToRemove);
            }
            return allPosts;
        }

        public async Task<Response> CreatePost(Post post)
        {
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

       

        public async Task<List<Post>> FindPostByUsername(UserAccount user)
        {
            return await _postManager.SearchPostByUser(user);
        }
    }
}
