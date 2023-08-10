using Business.Models;

namespace Business.Interfaces
{
    public interface IProductRepository: IRepository<Product>
    {
        Task<IEnumerable<Product>> GetProductsByProvider(Guid providerId);

        Task<IEnumerable<Product>> GetProductsAndProviders();

        Task<Product> GetProductandProvider(Guid id);

    }
}
