using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterviewBoard.Models;

namespace InterviewBoard.Repository
{
    public interface IAcceptOperations
    {
        public Task<List<Accept>> AllAccepts();
        public Task<List<Accept>> AllAcceptsBasedUsername(string username);
    }
}
