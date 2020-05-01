using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterviewBoard.Models;
using InterviewBoard.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace InterviewBoard.Service
{
    public class PostService : IPostOperations
    {
        private readonly ApplicationDbContext _db;
        public PostService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<List<Post>> AllPosts()
        {
            return await _db.Post.ToListAsync();
        }

        public async Task CreatePost(Post post)
        {
            await _db.Post.AddAsync(post);
            await _db.SaveChangesAsync();
        }

        public async Task<List<Post>> AllPostsWithUser(UserAcc user)
        {
            return await _db.Post.Where(d => d.user == user).ToListAsync();
        }

        public async Task<Post> EditPost(Post post)
        {
            var postE = await FindPostWithId(post.PostId);
            postE.Title = post.Title;
            postE.Content = post.Content;
            await _db.SaveChangesAsync();
            return postE;
        }

        public async Task DeletePost(int id)
        {
            Post post = await FindPostWithId(id);
            var result = _db.Post.Remove(post);
            await _db.SaveChangesAsync();
        }

        public async Task<Post> FindPostWithId(int id)
        {
            return await _db.Post.Where(d => d.PostId == id).SingleAsync();
        }


        public async Task<List<Post>> AllPostForSeeker(List<Accept> accepts)
        {
            List<Post> posts = await AllPosts();
            List<Post> Addit = new List<Post>();
            
            foreach (var post in posts)
            {
                var flag = true;
                foreach (var accept in accepts)
                {
                    if (accept.PostId == post.PostId) flag = false;
                    

                }

                if (flag == true)
                {
                    Addit.Add(post);
                }
            }

            return Addit;
        }

    }
}
