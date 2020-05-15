using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ManagerService.Manager.AuthenticationManager.UserInfoManager;
using Models;
using Models.View_Model;

namespace AuthenticationService.UserInformation
{
    public class UserInfoService : IUserInfo
    {
        private readonly UserInfoManager _userInfoManager;
        public UserInfoService(UserInfoManager userInfoManager)
        {
            _userInfoManager = userInfoManager;
        }


        public async Task<UserAccount> GetUser(string username)
        {
            return await _userInfoManager.getUser(username);
        }

        public async Task<string> GetUserRole(string username)
        {
            return await _userInfoManager.getUserRole(username);
        }

        public async Task<UserInfo> GetUserDetailes(string username)
        {
            return new UserInfo(await GetUser(username),await GetUserRole(username));
        }
    }
}
