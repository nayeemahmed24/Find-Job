using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterviewBoard.Models;
using InterviewBoard.Repository;
using Microsoft.EntityFrameworkCore;

namespace InterviewBoard.Service
{
    public class AcceptService : IAcceptOperations
    {
        private readonly ApplicationDbContext _db;
        public AcceptService(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<List<Accept>> AllAccepts()
        {
            return await _db.Accept.ToListAsync();
        }

        public async Task<List<Accept>> AllAcceptsBasedUsername(string username)
        {
            return await _db.Accept.Where(d => d.Username == username).ToListAsync();
        }

        public async Task<List<Accept>> AllAcceptBasedOnPostId(int postid)
        {
            return await _db.Accept.Where(d => d.PostId == postid).ToListAsync();
        }

        public async Task Create(Accept accept)
        {
            await _db.Accept.AddAsync(accept);
            await _db.SaveChangesAsync();
        }
    }
}
