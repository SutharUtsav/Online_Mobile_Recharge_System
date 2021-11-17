using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OnlineMobileRechargeSystem.Models
{
    public class SQLProviderRepository:IProviderRepository
    {
        private readonly AppDbContext context;
        string[] list = { "Unlimited", "TopUp", "Recommanded", "Data", "Others" };

        public SQLProviderRepository(AppDbContext context)
        {
            this.context = context;

        }

        Provider IProviderRepository.Add(Provider provider)
        {
            context.Providers.Add(provider);
            context.SaveChanges();
            
            context.Types.Add(new TypeofRecharge { provider = provider, RechargeType = list[0] });
            context.SaveChanges();
            
            context.Types.Add(new TypeofRecharge { provider = provider, RechargeType = list[1] });
            context.SaveChanges();

            context.Types.Add(new TypeofRecharge { provider = provider, RechargeType = list[2] });
            context.SaveChanges();

            context.Types.Add(new TypeofRecharge { provider = provider, RechargeType = list[3] });
            context.SaveChanges();

            context.Types.Add(new TypeofRecharge { provider = provider, RechargeType = list[4] });
            context.SaveChanges();
            return provider;
        }

        Provider IProviderRepository.Delete(int Id)
        {
            Provider p = context.Providers.Find(Id);
            if(p != null)
            {
                context.Providers.Remove(p);
                context.SaveChanges();
            }
            return p;
        }

        IEnumerable<Provider> IProviderRepository.GetAllProvider()
        {
            return context.Providers;
        }

        Provider IProviderRepository.GetProvider(int Id)
        {
            return context.Providers.FirstOrDefault(p => p.Id == Id);
        }

        Provider IProviderRepository.Update(Provider UpdatedProvider)
        {
            var provider = context.Providers.Attach(UpdatedProvider);
            provider.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return UpdatedProvider;
        }
    }
}
