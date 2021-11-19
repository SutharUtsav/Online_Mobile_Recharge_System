using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMobileRechargeSystem.Models
{
    public interface IProviderRepository
    {
        Provider GetProvider(int Id);
        IEnumerable<Provider> GetAllProvider();
        Provider Add(Provider provider);
        Provider Update(Provider UpdatedProvider);
        Provider Delete(int Id);


    }
}
