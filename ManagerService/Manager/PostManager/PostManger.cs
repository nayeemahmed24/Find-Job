using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Migrations;
using Models;
using Models.Model;

namespace ManagerService.Manager.PostManager
{
    public class PostManger : IPostManager
    {
        private readonly ApplicationDbContext _db;

        public PostManger(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<Response> Create(Post post)
        {
            var result = await _db.Post.AddAsync(post);
            await _db.SaveChangesAsync();
            if (result != null)
            {
                return new Response(true);
            }
            return new Response(false);

        }

        public async Task<Response> EditPost(Post Newpost,Post PrevPost)
        {
            Post post = await SearchPostByPostId(PrevPost.PostId);
            post.Content = Newpost.Content;
            post.Title = Newpost.Title;
            var res = await _db.SaveChangesAsync();
            return new Response(true);

        }

        public async Task<Response> DeletePost(Post post)
        {
            var respose =  _db.Remove(post);
            if (respose != null)
            {
                await _db.SaveChangesAsync();
                return new Response(true);
            }

            return new Response(false);
        }


        public async Task<Post> SearchPostByPostId(int postid)
        {
            return await _db.Post.Where(d => d.PostId == postid).SingleAsync<Post>();
        }

        public async Task<List<Post>> SearchPostByUser(UserAccount user)
        {
            return await _db.Post.Where(u => u.user == user).ToListAsync();
        }
    }
}
