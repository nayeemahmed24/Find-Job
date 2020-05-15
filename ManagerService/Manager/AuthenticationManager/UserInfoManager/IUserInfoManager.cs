using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace ManagerService.Manager.AuthenticationManager.UserInfoManager
{
    public interface IUserInfoManager
    {
        Task<UserAccount> getUser(string username);
        Task<string> getUserRole(string username);

    }
}
