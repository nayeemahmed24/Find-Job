using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Models;
using Models.Model;

namespace ManagerService.Manager.PostManager
{
    public interface IPostManager
    {
        public Task<List<Post>> AllPosts();
        public Task<Response> Create(Post post);
        public Task<Response> EditPost(Post Newpost, Post PrevPost);
        public Task<Response> DeletePost(Post post);
        public Task<Post> SearchPostByPostId(int postid);
        public Task<List<Post>> SearchPostByUser(UserAccount user);
    }
}
