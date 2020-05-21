using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Models;
using Models.Model;

namespace Manager.Manager.ApplyManager
{
    public interface IApplyManager
    {
        public Task<List<Apply>> FindApplyByUserAccount(UserAccount user);
    }
}
