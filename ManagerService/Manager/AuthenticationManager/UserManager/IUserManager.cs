using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Models;
using Models.Model;

namespace ManagerService.Manager.AuthenticationManager.UserManager
{
    public interface IUserManager
    {
        Task<Response> Login(string username, string password);
        Task<Response> Register(UserAccount user, string password,string rolename);
        Task<Response> Logout();
    }
}
