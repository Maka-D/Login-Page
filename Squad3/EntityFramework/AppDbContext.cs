using Microsoft.EntityFrameworkCore;
using Squad3.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Squad3.EntityFramework
{
    public class AppDbContext :DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext>options) : base(options)
        {

        }

        public DbSet<UsersCore> Users { get; set; }
        public DbSet<UsersFirstDetailsInfoCore> UsersFirstDetailsInfoCores { get; set; } 
    }
   
}
