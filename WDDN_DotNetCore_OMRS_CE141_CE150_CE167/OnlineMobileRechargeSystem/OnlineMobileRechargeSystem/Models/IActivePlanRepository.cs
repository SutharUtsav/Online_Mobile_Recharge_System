using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMobileRechargeSystem.Models
{
    public interface IActivePlanRepository
    {
        IEnumerable<ActivePlan> GetAllActivePlan(string Id);
        ActivePlan Add(ActivePlan activePlan);
    }
}
