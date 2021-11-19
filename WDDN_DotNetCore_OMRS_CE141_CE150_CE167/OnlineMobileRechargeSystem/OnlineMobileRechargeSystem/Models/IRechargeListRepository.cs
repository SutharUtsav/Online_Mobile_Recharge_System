using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMobileRechargeSystem.Models
{
    public interface IRechargeListRepository
    {
        RechargeList GetRecharge(int Id);
        IEnumerable<RechargeList> GetRechargeList();
        IEnumerable<RechargeList> GetRechargeListFilter(int PId,int TId);
        RechargeList Add(RechargeList RechargeList);
        RechargeList Update(RechargeList UpdatedRechargeList);
        RechargeList Delete(int Id);
    }
}
