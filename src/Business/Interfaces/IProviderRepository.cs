using Business.Models;


namespace Business.Interfaces
{
   public interface IProviderRepository: IRepository<Provider>
    {
        Task<Provider> GetAddressProvider(Guid id);
        Task<Provider> GetAddressProductProvider(Guid id);
    }
}
