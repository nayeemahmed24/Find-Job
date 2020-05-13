using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Models.Model;

namespace ManagerService.Manager.PostManager
{
    public interface IPostManager
    {
        Task<Response> Create(Post post);
    }
}
