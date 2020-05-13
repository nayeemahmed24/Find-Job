using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationService
{
    public interface IUserAuth
    {
        Task Login();
        Task Register();
        Task Logout();
    }
}
