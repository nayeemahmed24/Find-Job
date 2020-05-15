using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Models;
using Models.Model;

namespace AuthenticationService
{
    public interface IUserAuth
    {
        Task<Response> Login(string username,string password);
        Task<Response> Register(UserAccount user,string password, string rolename);
        Task<Response> Logout();
    }
}
