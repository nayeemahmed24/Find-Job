using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Models;

namespace ManagerService.Manager.AuthenticationManager.UserInfoManager
{
    public class UserInfoManager: IUserInfoManager
    {
        private readonly UserManager<UserAccount> _userManager;
        public UserInfoManager(UserManager<UserAccount> userManager)
        {
            _userManager = userManager;
        }
        public async Task<UserAccount> getUser(string username)
        {
            
            UserAccount currentUser = new UserAccount();
            if (username != null)
            {
                currentUser = await _userManager.FindByNameAsync(username);
            }

            return currentUser;
        }


        public async Task<string> getUserRole(string username)
        {
            string Role = "giver";
            if (username != null)
            {
                UserAccount currentUser = await _userManager.FindByNameAsync(username);

                if (await _userManager.IsInRoleAsync(currentUser, "seeker"))
                {
                    Role = "seeker";
                }
            }
            else
            {
                Role = "";
            }
            return Role;
        }
    }
}
