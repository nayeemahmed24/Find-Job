using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Migrations;
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
            await _db.Post.AddAsync(post);
            await _db.SaveChangesAsync();
            return new Response(true);
        }
    }
}
