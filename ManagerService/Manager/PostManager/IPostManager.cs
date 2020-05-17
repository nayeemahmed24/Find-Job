using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Models.Model;

namespace ManagerService.Manager.PostManager
{
    public interface IPostManager
    {
        Task<Response> Create(Post post);
        public Task<Response> EditPost(Post Newpost, Post PrevPost);
        public Task<Response> DeletePost(Post post);
        public Task<Post> SearchPostByPostId(int postid);
    }
}
