using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterviewBoard.Models;
using InterviewBoard.Repository;
using Microsoft.EntityFrameworkCore;

namespace InterviewBoard.Service
{
    public class ChatService :IChatOperations
    {
        private readonly ApplicationDbContext _db;
        public ChatService(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task CreateMessage(Messege messege)
        {
            await _db.Messege.AddAsync(messege);
            await _db.SaveChangesAsync();
        }

        public async Task<List<Messege>> AllMessagesWithUsername(string senderUserName, string recieveUsername)
        {
            return await _db.Messege.Where(d => (d.SenderUsername == senderUserName && d.ReciverUsername == recieveUsername) || (d.SenderUsername == recieveUsername && d.ReciverUsername == senderUserName)).ToListAsync();
        }
    }
}
