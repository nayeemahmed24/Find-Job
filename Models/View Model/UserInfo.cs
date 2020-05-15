using System;
using System.Collections.Generic;
using System.Text;

namespace Models.View_Model
{
    public class UserInfo
    {
        public UserInfo(UserAccount _user, string _roleName)
        {
            user = _user;
            roleName = _roleName;
        }
        public UserAccount user { get; set; }
        public string roleName { get; set; }
    }
}
