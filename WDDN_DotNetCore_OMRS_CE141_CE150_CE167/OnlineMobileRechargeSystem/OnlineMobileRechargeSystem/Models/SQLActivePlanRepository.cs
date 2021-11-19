using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineMobileRechargeSystem.ViewModels;

namespace OnlineMobileRechargeSystem.Models
{
    public class SQLActivePlanRepository  : IActivePlanRepository
    {
        private readonly AppDbContext context;
        public SQLActivePlanRepository(AppDbContext context)
        {
            this.context = context;
        }

        ActivePlan IActivePlanRepository.Add(ActivePlan activePlan)
        {
            context.activePlans.Add(activePlan);
            context.SaveChanges();
            return activePlan;
        }

        IEnumerable<ActivePlan> IActivePlanRepository.GetAllActivePlan(string Id)
        {
            var model = (from A in context.activePlans where A.Uid == Id select A).Include(A=>A.Recharge);
            return model;
        }
    }
}
