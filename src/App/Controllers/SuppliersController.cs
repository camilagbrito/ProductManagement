using App.ViewModels;
using AutoMapper;
using Business.Interfaces;
using Business.Models;
using Data.Repository;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    [Route("admin-suppliers")]
    public class SuppliersController : BaseController
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;

        public SuppliersController(ISupplierRepository supplierRepository, IAddressRepository addressRepository, IMapper mapper)
        {
            _supplierRepository = supplierRepository;
            _addressRepository = addressRepository;
            _mapper = mapper;
        }

        [Route("suppliers-list")]

        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<SupplierViewModel>>(await _supplierRepository.GetAll()));
        }

        [Route("supplier-details/{id:guid}")]
        public async Task<IActionResult> Details(Guid id)
        {

            var supplierViewModel = await GetSupplierAddress(id);

            if (supplierViewModel == null)
            {
                return NotFound();
            }

            return View(supplierViewModel);
        }

        [Route("new-supplier")]
        public IActionResult Create()
        {
            return View();
        }

        [Route("new-supplier")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SupplierViewModel supplierViewModel)
        {
            if (!ModelState.IsValid) return View(supplierViewModel);

            var supplier = _mapper.Map<Supplier>(supplierViewModel);
            await _supplierRepository.Add(supplier);

            return RedirectToAction(nameof(Index));
        }

        [Route("edit-supplier/{id:guid}")]
        public async Task<IActionResult> Edit(Guid id)
        {

            var supplierViewModel = await GetAddressProductSupplier(id);

            if (supplierViewModel == null)
            {
                return NotFound();
            }

            return View(supplierViewModel);
        }

        [Route("edit-supplier/{id:guid}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, SupplierViewModel supplierViewModel)
        {
            if (id != supplierViewModel.Id) return NotFound();

            if (!ModelState.IsValid) return View(supplierViewModel);

            var supplier = _mapper.Map<Supplier>(supplierViewModel);

            await _supplierRepository.Update(supplier);

            return RedirectToAction(nameof(Index));

        }

        [Route("delete-supplier/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var supplierViewModel = await GetSupplierAddress(id);

            if (supplierViewModel == null)
            {
                return NotFound();
            }

            return View(supplierViewModel);
        }

        [Route("delete-supplier/{id:guid}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {

            var supplierViewModel = await GetSupplierAddress(id);

            if (supplierViewModel == null) return NotFound();


            await _supplierRepository.Delete(id);

            return RedirectToAction(nameof(Index));
        }

        [Route("get-supplier-address/{id:guid}")]
        public async Task<IActionResult> GetAddress(Guid id)
        {
            var supplier = await GetSupplierAddress(id);

            if(supplier == null)
            {
                return NotFound();
            }

            return PartialView("_DetailsAddress", supplier);
        }

        [Route("update-supplier-address/{id:guid}")]
        public async Task<IActionResult> UpdateAddress(Guid id)
        {
            var supplier = await GetSupplierAddress(id);

            if (supplier == null)
            {
                return NotFound();
            }

            return PartialView("_UpdateAddress", new SupplierViewModel { Address = supplier.Address });
        }

        [Route("update-supplier-address/{id:guid}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateAddress(SupplierViewModel supplierViewModel)
        {
            ModelState.Remove("Name");
            ModelState.Remove("IdentityCard");

            if (!ModelState.IsValid) return PartialView("_UpdateAddress", supplierViewModel);

            await _addressRepository.Update(_mapper.Map<Address>(supplierViewModel.Address));

            var url = Url.Action("GetAddress", "Suppliers", new { id = supplierViewModel.Address.SupplierId});

            return Json(new { success = true, url });

        }

        private async Task<SupplierViewModel> GetSupplierAddress(Guid id)
        {
            return _mapper.Map<SupplierViewModel>(await _supplierRepository.GetAddressSupplier(id));
        }

        private async Task<SupplierViewModel> GetAddressProductSupplier(Guid id)
        {
            return _mapper.Map<SupplierViewModel>(await _supplierRepository.GetAddressProductSupplier(id));
        }
    }
}
