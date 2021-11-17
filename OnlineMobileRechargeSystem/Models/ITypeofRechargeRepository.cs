using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMobileRechargeSystem.Models
{
    public interface ITypeofRechargeRepository
    {
        TypeofRecharge GetType(int Id);
        IEnumerable<TypeofRecharge> GetAllType();
        IEnumerable<TypeofRecharge> GetTypeswithId(int Id);
        TypeofRecharge Add(TypeofRecharge type);

    }
}
