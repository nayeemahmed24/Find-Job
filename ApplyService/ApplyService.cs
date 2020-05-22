using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Manager.Manager.ApplyManager;
using Models;
using Models.Model;

namespace ApplyService
{
    public class ApplyService :IApplyService
    {
        private readonly ApplyManger _applyManger;
        public ApplyService(ApplyManger applyManger)
        {
            _applyManger = applyManger;
        }
        public async Task<List<Apply>> FindApplyByUserAccout(UserAccount user)
        {
            return await _applyManger.FindApplyByUserAccount(user);
        }

        public async Task<Response> Create(Apply apply)
        {
            return await _applyManger.CreateApply(apply);
        }

        
    }
}
