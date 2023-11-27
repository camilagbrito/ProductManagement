using Business.Interfaces;
using Business.Models;
using Business.Models.Validations;

namespace Business.Services
{
    public class SupplierService : BaseService, ISupplierService
    {
        public ISupplierRepository _supplierRepository;
        public IAddressRepository _addressRepository;

        public SupplierService(ISupplierRepository supplierRepository, IAddressRepository addressRepository, INotificator notificator)
            :base(notificator)
        {
            _supplierRepository = supplierRepository;
            _addressRepository = addressRepository;
        }

        public async Task Add(Supplier supplier)
        {
            if (!ExecuteValidation(new SupplierValidation(), supplier)
                || !ExecuteValidation(new AdressValidation(), supplier.Address)) return;
            if(_supplierRepository.Search(x => x.IdentityCard == supplier.IdentityCard).Result.Any() )
            {
                Notify("Já existe um fornecedor com o documento informado.");
                return;
            }

            await _supplierRepository.Add(supplier);
        }

        public async Task Update(Supplier supplier)
        {
            if (!ExecuteValidation(new SupplierValidation(), supplier)) return;

            if (_supplierRepository.Search(x => x.IdentityCard == supplier.IdentityCard && x.Id != supplier.Id).Result.Any())
            {
                Notify("Já existe um fornecedor com o documento informado.");
                return;
            }
            
            await _supplierRepository.Update(supplier);

        }


        public async Task UpdateAddress(Address address)
        {
            if (!ExecuteValidation(new AdressValidation(), address)) return;

            await _addressRepository.Update(address);
        }

        public async Task Delete(Guid id)
        {
            if (_supplierRepository.GetAddressProductSupplier(id).Result.Products.Any())
            {
                Notify("O fornecedor possui produtos cadastrados!");
                return;
            }

            var address = await _addressRepository.GetAddressBySupplier(id);
            if(address != null)
            {
                await _addressRepository.Delete(address.Id);
            }

            await _supplierRepository.Delete(id);

        }

        public void Dispose()
        {
            _supplierRepository?.Dispose();
           _addressRepository?.Dispose();
        }
    }
}
