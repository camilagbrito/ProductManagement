using Business.Models;


namespace Business.Interfaces
{
    public interface IAddressRepository: IRepository<Address>
    {
        Task<Address> GetAddressByProvider(Guid providerId);
    }
}
