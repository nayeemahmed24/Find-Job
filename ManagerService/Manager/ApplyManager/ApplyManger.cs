using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Migrations;
using Models;
using Models.Model;

namespace Manager.Manager.ApplyManager
{
    public class ApplyManger:IApplyManager
    {
        private readonly ApplicationDbContext _db;
        public ApplyManger(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<List<Apply>> FindApplyByUserAccount(UserAccount user)
        {
            return await _db.Apply.Where(d => d.user == user).ToListAsync();
        }
    }
}
