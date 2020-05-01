using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterviewBoard.Models;

namespace InterviewBoard.Repository
{
    public interface IChatOperations
    {
        public Task CreateMessage(Messege messege);
        public Task<List<Messege>> AllMessagesWithUsername(string senderUserName, string recieveUsername);
    }
}
