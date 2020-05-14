using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ManagerService.Manager.AuthenticationManager.RoleManager;
using Microsoft.AspNetCore.Identity;

using Models;
using Models.Model;

namespace ManagerService.Manager.AuthenticationManager.UserManager
{
    public class UserManagerBase :IUserManager
    {
        private readonly SignInManager <UserAccount> _signInManager;
        private readonly UserManager<UserAccount> _userManager;
        
        
        public UserManagerBase(UserManager<UserAccount> userManager,SignInManager<UserAccount> signInManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }
        public async Task<Response> Login(string username, string password)
        {
            var user = await _userManager.FindByNameAsync(username);
            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user, password, false, false);
                if (result.Succeeded)
                {
                    return new Response(true);
                }
            }
            return new Response(false);
        }

        public async Task<Response> Register(UserAccount user, string password, string rolename)
        {
            var result = await _userManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                var resultRole = await _userManager.AddToRoleAsync(user, rolename);
            }
            return new Response(false);
        }

        public Task<Response> Logout()
        {
            throw new NotImplementedException();
        }
    }
}
