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
    public class Authenticator : IUserAuth
    {
        private readonly RoleManagerBase _roleManagerBase;

        private readonly UserManagerBase _userManagerBase;

        public Authenticator(RoleManagerBase roleManagerBase,UserManagerBase userManagerBase)
        {
            _roleManagerBase = roleManagerBase;
            _userManagerBase = userManagerBase;
        }

        public async  Task<Response> Login(string username, string password)
        {
            throw new NotImplementedException();

        }

        public async Task<Response> Register(UserAccount user,string password, string rolename)
        {

            throw new NotImplementedException();
        }

        public async Task<Response> Logout()
        {
            throw new NotImplementedException();
        }
    }
}
