using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Models;
using Models.Model;
using Models.View_Model;

namespace PostService
{
    public interface IPostService
    {
        public Task<List<Post> > AllPosts(UserInfo user);
        public Task<Response> CreatePost(Post post);
        public Task<Response> EditPost(Post Newpost, Post PrevPost);
        public Task<Response> DeletePost(int id);
        public Task<Post> FindPostById(int id);
        public Task<List<Post>> FindPostByUsername(UserAccount user);
        public Task<List<Post>> FindPostByApplies(List<Apply> applies);
    }
}
