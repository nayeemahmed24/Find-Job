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
            await _postManager.Create(post);
            return new Response(true);
        }
    }
}
