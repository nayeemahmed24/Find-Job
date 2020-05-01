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

    }
}
