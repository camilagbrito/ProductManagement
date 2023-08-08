using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
   public interface IProviderRepository: IRepository<Provider>
    {
        Task<Provider> GetAdressProvider(Guid id);
        Task<Provider> GetAdressProductProvider(Guid id);
    }
}
