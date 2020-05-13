using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Models.Model;

namespace ManagerService.Manager.AuthenticationManager.RoleManager
{
    public class RoleManagerBase : IRoleManager
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        public RoleManagerBase(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public async Task<Response> CreateRole(string RoleName)
        {
            if (await _roleManager.FindByNameAsync(RoleName) == null)
            {
                IdentityResult CreateRole = await _roleManager.CreateAsync(new IdentityRole(RoleName));
                return new Response(true);
            }
            return new Response(false);

        }

        public Task<Response> DeleteRole(string RoleName)
        {
            throw new NotImplementedException();
        }
    }
}
