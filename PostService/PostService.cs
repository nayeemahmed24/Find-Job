using System;
using System.Threading.Tasks;
using ManagerService.Manager.PostManager;
using Models.Model;

namespace PostService
{
    public class PostService : IPostService
    {
        private readonly PostManger _postManager;
        public PostService(PostManger postManager)
        {
            _postManager = postManager;
        }
        public async Task<Response> CreatePost(Post post)
        {
            return await _postManager.Create(post);
        }

        public async Task<Response> EditPost(Post Newpost,Post PrevPost)
        {
            return await _postManager.EditPost(Newpost, PrevPost);
        }

        public async Task<Response> DeletePost(Post post)
        {
            return await _postManager.DeletePost(post);
        }
    }
}
