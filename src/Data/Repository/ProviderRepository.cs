using Business.Interfaces;
using Business.Models;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.Repository
{
    public class ProviderRepository : Repository<Provider>, IProviderRepository
    {
        public ProviderRepository(ProductManagementContext db) : base(db){}

        public async Task<Provider> GetAddressProvider(Guid id)
        {
            return await Db.Providers.AsNoTracking()
                .Include(x => x.Address).
                FirstOrDefaultAsync(x => x.Id == id);  
        }

        public async Task<Provider> GetAddressProductProvider(Guid id)
        {
            return await Db.Providers.AsNoTracking()
                 .Include(x => x.Products)
                 .Include(x => x.Address)
                 .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
