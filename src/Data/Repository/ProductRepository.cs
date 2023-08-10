using Business.Interfaces;
using Business.Models;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ProductManagementContext db) : base(db){}

        public async Task<Product> GetProductandProvider(Guid id)
        {
            return await Db.Products.AsNoTracking().Include(x => x.Provider)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Product>> GetProductsAndProviders()
        {
            return await Db.Products.AsNoTracking().Include(x => x.Provider)
                .OrderBy(x => x.Name).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsByProvider(Guid providerId)
        {
            return await Search(x => x.ProviderId == providerId);
        }
    }
}
