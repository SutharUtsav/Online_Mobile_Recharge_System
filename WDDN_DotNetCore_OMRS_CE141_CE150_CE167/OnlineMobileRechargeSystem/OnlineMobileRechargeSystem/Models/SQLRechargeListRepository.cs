using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMobileRechargeSystem.Models
{
    public class SQLRechargeListRepository : IRechargeListRepository
    {
        private readonly AppDbContext context;
        public SQLRechargeListRepository(AppDbContext context)
        {
            this.context = context;
        }
        RechargeList IRechargeListRepository.Add(RechargeList RechargeList)
        {
            context.RechargeList.Add(RechargeList);
            context.SaveChanges();
            return RechargeList;
        }

        RechargeList IRechargeListRepository.Delete(int Id)
        {
            RechargeList r = context.RechargeList.Find(Id);
            if(r != null)
            {
                context.RechargeList.Remove(r);
                context.SaveChanges();
                return r;
            }
            return r;
        }

        RechargeList IRechargeListRepository.GetRecharge(int Id)
        {
            return context.RechargeList.FirstOrDefault(r => r.Id == Id);
        }

        IEnumerable<RechargeList> IRechargeListRepository.GetRechargeList()
        {
            return context.RechargeList.Include(r => r.Provider).Include(r => r.Type);
        }

        IEnumerable<RechargeList> IRechargeListRepository.GetRechargeListFilter(int PId, int TId)
        {
            return (from r in context.RechargeList where r.Provider.Id == PId && r.Type.Id == TId select r).Include(r=>r.Provider).Include(r=>r.Type); 
        }

        RechargeList IRechargeListRepository.Update(RechargeList UpdatedRechargeList)
        {
            var recharge = context.RechargeList.Attach(UpdatedRechargeList);
            recharge.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return UpdatedRechargeList;
        }
    }
}
