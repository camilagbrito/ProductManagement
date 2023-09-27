using Business.Models;


namespace Business.Interfaces
{
   public interface ISupplierRepository: IRepository<Supplier>
    {
        Task<Supplier> GetAddressSupplier(Guid id);
        Task<Supplier> GetAddressProductSupplier(Guid id);
    }
}
