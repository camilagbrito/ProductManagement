using Business.Interfaces;
using Business.Models;
using Business.Models.Validations;

namespace Business.Services
{
    public class ProductService : BaseService, IProductService
    {
        public readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository, INotificator notificator)
            :base(notificator) 
        {
           _productRepository = productRepository;
        }

        public async Task Add(Product product)
        {
            if (!ExecuteValidation(new ProductValidation(), product)) return;
        
            await _productRepository.Add(product);
        }

        public async Task Update(Product product)
        {
            if (!ExecuteValidation(new ProductValidation(), product)) return;
            
            await _productRepository.Update(product);
        }

        public async Task Delete(Guid id)
        {
            await _productRepository.Delete(id);
        }

        public async void Dispose()
        {
           _productRepository?.Dispose();
        }
    }
}
