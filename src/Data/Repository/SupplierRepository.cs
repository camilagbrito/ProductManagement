using Business.Interfaces;
using Business.Models;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.Repository
{
    public class SupplierRepository : Repository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(ProductManagementContext db) : base(db){}

        public async Task<Supplier> GetAddressSupplier(Guid id)
        {
            return await Db.Suppliers.AsNoTracking()
                .Include(x => x.Address).
                FirstOrDefaultAsync(x => x.Id == id);  
        }

        public async Task<Supplier> GetAddressProductSupplier(Guid id)
        {
            return await Db.Suppliers.AsNoTracking()
                 .Include(x => x.Products)
                 .Include(x => x.Address)
                 .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
