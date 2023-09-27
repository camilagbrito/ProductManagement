﻿using App.ViewModels;
using AutoMapper;
using Business.Interfaces;
using Business.Models;
using Data.Repository;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{

    public class SuppliersController : BaseController
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IMapper _mapper;

        public SuppliersController(ISupplierRepository supplierRepository, IMapper mapper)
        {
            _supplierRepository = supplierRepository;
            _mapper = mapper; 
        }

        public async Task<IActionResult> Index()
        {
              return View(_mapper.Map<IEnumerable<SupplierViewModel>> (await _supplierRepository.GetAll()));
        }

        public async Task<IActionResult> Details(Guid id)
        {

            var supplierViewModel = await GetSupplierAddress(id);
                
            if (supplierViewModel == null)
            {
                return NotFound();
            }

            return View(supplierViewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SupplierViewModel supplierViewModel)
        {
            if (!ModelState.IsValid) return View(supplierViewModel);

            var supplier = _mapper.Map<Supplier>(supplierViewModel);
            await _supplierRepository.Add(supplier);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(Guid id)
        {

            var supplierViewModel = await GetAddressProductSupplier(id);

            if (supplierViewModel == null)
            {
                return NotFound();
            }

            return View(supplierViewModel);
        }

      
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

        public async Task<IActionResult> Delete(Guid id)
        {
            var supplierViewModel = await GetSupplierAddress(id); 
            
            if (supplierViewModel == null)
            {
                return NotFound();
            }

            return View(supplierViewModel);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {

            var supplierViewModel = await GetSupplierAddress(id);

            if (supplierViewModel == null) return NotFound();


            await _supplierRepository.Delete(id);

            return RedirectToAction(nameof(Index));
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
