using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMobileRechargeSystem.Models
{
    public class SQLTypeofRechargeRepository : ITypeofRechargeRepository
    {
        private readonly AppDbContext context;
        string[] list = { "Unlimited","TopUp" ,"Recommanded","Data","Others"};
        public SQLTypeofRechargeRepository(AppDbContext context)
        {
            this.context = context;
        }
        TypeofRecharge ITypeofRechargeRepository.Add(TypeofRecharge type)
        {
            context.Types.Add(type);
            context.SaveChangesAsync();
            return type;
        }

        IEnumerable<TypeofRecharge> ITypeofRechargeRepository.GetAllType()
        {
            return context.Types;
        }

        IEnumerable<TypeofRecharge> ITypeofRechargeRepository.GetTypeswithId(int Id)
        {
            var type = from t in context.Types where t.provider.Id == Id select t;
            return type;
        }
        TypeofRecharge ITypeofRechargeRepository.GetType(int Id)
        {
            return context.Types.FirstOrDefault(t => t.Id == Id);
        }
    }
}
