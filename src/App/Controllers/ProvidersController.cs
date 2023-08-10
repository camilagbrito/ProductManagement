using App.ViewModels;
using AutoMapper;
using Business.Interfaces;
using Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{

    public class ProvidersController : BaseController
    {
        private readonly IProviderRepository _providerRepository;
        private readonly IMapper _mapper;

        public ProvidersController(IProviderRepository providerRepository, IMapper mapper)
        {
            _providerRepository = providerRepository;
            _mapper = mapper; 
        }

        public async Task<IActionResult> Index()
        {
              return View(_mapper.Map<IEnumerable<ProviderViewModel>> (await _providerRepository.GetAll()));
        }

        public async Task<IActionResult> Details(Guid id)
        {

            var providerViewModel = await GetProviderAddress(id);
                
            if (providerViewModel == null)
            {
                return NotFound();
            }

            return View(providerViewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProviderViewModel providerViewModel)
        {
            if (!ModelState.IsValid) return View(providerViewModel);

            var provider = _mapper.Map<Provider>(providerViewModel);
            await _providerRepository.Add(provider);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(Guid id)
        {
          
            var providerViewModel = await GetAddressProductProvider(id);

            if (providerViewModel == null)
            {
                return NotFound();
            }

            return View(providerViewModel);
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, ProviderViewModel providerViewModel)
        {
            if (id != providerViewModel.Id) return NotFound();

            if (!ModelState.IsValid) return View(providerViewModel);

            var provider = _mapper.Map<Provider>(providerViewModel);

            await _providerRepository.Update(provider);

            return RedirectToAction(nameof(Index));
             
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var providerViewModel = await GetProviderAddress(id); 
            
            if (providerViewModel == null)
            {
                return NotFound();
            }

            return View(providerViewModel);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            
            var providerViewModel = await GetProviderAddress(id);

            if (providerViewModel == null) return NotFound();


            await _providerRepository.Delete(id);

            return RedirectToAction(nameof(Index));
        }

        private async Task<ProviderViewModel> GetProviderAddress(Guid id)
        {
            return _mapper.Map<ProviderViewModel>(await _providerRepository.GetAdressProvider(id));
        }

        private async Task<ProviderViewModel> GetAddressProductProvider(Guid id)
        {
            return _mapper.Map<ProviderViewModel>(await _providerRepository.GetAdressProductProvider(id));
        }
    }
}
