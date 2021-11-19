using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OnlineMobileRechargeSystem.Models
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        { 
        }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<TypeofRecharge> Types { get; set; }
        public DbSet<RechargeList> RechargeList { get; set; }
        public DbSet<ActivePlan> activePlans { get; set; }
    }
}
