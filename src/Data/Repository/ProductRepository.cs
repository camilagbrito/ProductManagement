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

        public async Task<Product> GetProductAndSupplier(Guid id)
        {
            return await Db.Products.AsNoTracking().Include(x => x.Supplier)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Product>> GetProductsAndSuppliers()
        {
            return await Db.Products.AsNoTracking().Include(x => x.Supplier)
                .OrderBy(x => x.Name).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsBySupplier(Guid supplierId)
        {
            return await Search(x => x.SupplierId == supplierId);
        }
    }
}
