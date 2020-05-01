using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterviewBoard.Models;

namespace InterviewBoard.Repository
{
    public interface IPostOperations
    {
        public Task< List<Post>>  AllPosts();
        public Task CreatePost(Post post);
        public Task<Post> EditPost(Post post);
        public Task DeletePost(int id);
        public Task<Post> FindPostWithId(int id);
        public Task<List<Post>> AllPostsWithUser(UserAcc user);

    }
}
