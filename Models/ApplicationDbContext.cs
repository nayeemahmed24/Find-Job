using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InterviewBoard.Models
{
    public class ApplicationDbContext : IdentityDbContext<UserAcc>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Post> Post { get; set; }
        

        public DbSet<Accept> Accept { get; set; }

        public DbSet<Messege> Messege { get; set; }



    }
}
