using Business.Interfaces;
using Business.Models;
using Data.Context;
using Microsoft.EntityFrameworkCore;


namespace Data.Repository
{
    public class AddressRepository : Repository<Address>, IAddressRepository
    {
        public AddressRepository(ProductManagementContext db) : base(db){}

        public async Task<Address> GetAddressByProvider(Guid providerId)
        {
            return await Db.Addresses.AsNoTracking()
                .FirstOrDefaultAsync(x => x.ProviderId == providerId);
        }
    }
}
