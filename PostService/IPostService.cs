using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Models.Model;

namespace PostService
{
    public interface IPostService
    {
        public Task<Response> CreatePost(Post post,string username);
        public Task<Response> EditPost(Post Newpost, Post PrevPost);
        public Task<Response> DeletePost(int id);
        public Task<Post> FindPostById(int id);
        public Task<List<Post>> FindPostByUsername(string username);
    }
}
