using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IProductsRepository: IRepository<Product>
    {
        Task<IEnumerable<Product>> GetProductsByProvider(Guid providerId);

        Task<IEnumerable<Product>> GetProductsAndProviders();

        Task<Product> GetProductandProvider(Guid id);

    }
}
