using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Models;
using Models.View_Model;

namespace AuthenticationService.UserInformation
{
    public interface IUserInfo
    {
        Task<UserAccount> GetUser(string username);
        Task<string> GetUserRole(string username);
        Task<UserInfo> GetUserDetailes(string username);
    }
}
