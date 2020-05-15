using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ManagerService.Manager.AuthenticationManager.RoleManager;
using ManagerService.Manager.AuthenticationManager.UserManager;
using Models;
using Models.Model;

namespace AuthenticationService
{
    public class AuthenticatorService : IUserAuth
    {
        private readonly RoleManagerBase _roleManagerBase;

        private readonly UserManagerBase _userManagerBase;

        public AuthenticatorService(RoleManagerBase roleManagerBase,UserManagerBase userManagerBase)
        {
            _roleManagerBase = roleManagerBase;
            _userManagerBase = userManagerBase;
        }

        public async  Task<Response> Login(string username, string password)
        {
            return await _userManagerBase.Login(username, password);
            
        }

        public async Task<Response> Register(UserAccount user,string password, string rolename)
        {
            await _roleManagerBase.CreateRole(rolename);
            return await _userManagerBase.Register(user, password, rolename);
            
        }

        public async Task<Response> Logout()
        {
            return await _userManagerBase.Logout();
        }
    }
}
