using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Models.Model;

namespace ManagerService.Manager.AuthenticationManager.RoleManager
{
    public interface IRoleManager
    {
        Task<Response> CreateRole(string RoleName);
        Task<Response> DeleteRole(string RoleName);
    }
}
