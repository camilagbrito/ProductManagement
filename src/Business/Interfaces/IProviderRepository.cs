using Business.Models;


namespace Business.Interfaces
{
   public interface IProviderRepository: IRepository<Provider>
    {
        Task<Provider> GetAdressProvider(Guid id);
        Task<Provider> GetAdressProductProvider(Guid id);
    }
}
