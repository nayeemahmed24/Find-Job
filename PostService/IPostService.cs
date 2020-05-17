using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Models.Model;

namespace PostService
{
    public interface IPostService
    {
        public Task<Response> CreatePost(Post post);
        public Task<Response> EditPost(Post Newpost, Post PrevPost);
        public Task<Response> DeletePost(Post post);
    }
}
