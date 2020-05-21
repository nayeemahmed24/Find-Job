using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Models;
using Models.Model;

namespace ApplyService
{
    public interface IApplyService
    {
        public Task<List<Apply>> FindApplyByUserAccout(UserAccount user);
    }
}
