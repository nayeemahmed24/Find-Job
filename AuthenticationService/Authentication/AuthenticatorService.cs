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
            await _userManagerBase.Login(username, password);
            return new Response(true);
        }

        public async Task<Response> Register(UserAccount user,string password, string rolename)
        {
            await _roleManagerBase.CreateRole(rolename);
            await _userManagerBase.Register(user, password, rolename);
            return new Response(true);
        }

        public async Task<Response> Logout()
        {
            return await _userManagerBase.Logout();
        }
    }
}
