using App.Extensions;
using App.ViewModels;
using AutoMapper;
using Business.Interfaces;
using Business.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    [Authorize]
    [Route("admin-products")]
    public class ProductsController : BaseController
    {
        private readonly IProductRepository _productRepository;
        private readonly ISupplierRepository _supplierRepository;
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductsController(IProductRepository productRepository, IProductService productService, ISupplierRepository supplierRepository, IMapper mapper, INotificator notificator)
            :base(notificator)
        {
            _productRepository = productRepository;
            _productService = productService;
            _supplierRepository = supplierRepository;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [Route("products-list")]
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<ProductViewModel>>(await _productRepository.GetProductsAndSuppliers()));
        }

        [AllowAnonymous]
        [Route("product-details/{id:guid}")]
        public async Task<IActionResult> Details(Guid id)
        {

            var productViewModel = await GetProduct(id); 
               
            if (productViewModel == null)
            {
                return NotFound();
            }

            return View(productViewModel);
        }

        [ClaimsAuthorize("Product","Add")]
        [Route("new-product")]
        public async Task<IActionResult> Create()
        {
            var productViewModel = await SeedSuppliers(new ProductViewModel());
            return View(productViewModel);
        }

        [ClaimsAuthorize("Product", "Add")]
        [Route("new-product")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductViewModel productViewModel)
        {
            productViewModel = await SeedSuppliers(productViewModel);

            if (!ModelState.IsValid) return View(productViewModel);

            var imgPrefix = Guid.NewGuid() + "_";

            if(!await UploadFile(productViewModel.ImageUpload, imgPrefix))
            {
                return View(productViewModel);
            }

            productViewModel.Image = imgPrefix + productViewModel.ImageUpload.FileName;

            await _productService.Add(_mapper.Map<Product>(productViewModel));

            if (!ValidOperation()) return View(productViewModel);

            return RedirectToAction("Index");
        }

        [ClaimsAuthorize("Product", "Edit")]
        [Route("edit-product/{id:guid}")]
        public async Task<IActionResult> Edit(Guid id)
        {
           
            var productViewModel = await GetProduct(id);
            if (productViewModel == null)
            {
                return NotFound();
            }

            return View(productViewModel);
        }

        [ClaimsAuthorize("Product", "Edit")]
        [Route("edit-product/{id:guid}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, ProductViewModel productViewModel)
        {
            if (id != productViewModel.Id) return NotFound();

            var productUpdate = await GetProduct(id);

            productViewModel.Supplier = productUpdate.Supplier;
            productViewModel.Image = productUpdate.Image;

            if (!ModelState.IsValid) return View(productViewModel);

            if(productViewModel.ImageUpload != null)
            {
                var imgPrefix = Guid.NewGuid() + "_";

                if (!await UploadFile(productViewModel.ImageUpload, imgPrefix))
                {
                    return View(productViewModel);
                }

                productUpdate.Image = imgPrefix + productViewModel.ImageUpload.FileName;
                DeleteFile(productViewModel.Image);
            }

            productUpdate.Name = productViewModel.Name;
            productUpdate.Description = productViewModel.Description;
            productUpdate.Price = productViewModel.Price;
            productUpdate.IsActive = productViewModel.IsActive;

            await _productService.Update(_mapper.Map<Product>(productUpdate));

            if(!ValidOperation()) return View(productViewModel);

            return RedirectToAction(nameof(Index));
           
        }

        [ClaimsAuthorize("Product", "Delete")]
        [Route("delete-product/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var product = await GetProduct(id);

            if (id == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [ClaimsAuthorize("Product", "Delete")]
        [Route("delete-product/{id:guid}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var product = await GetProduct(id);

            if (id == null)
            {
                return NotFound();
            }
            DeleteFile(product.Image);

            await _productService.Delete(id);

            if(!ValidOperation()) return View(product);

            TempData["Success"] = "Produto excluído com sucesso!";

            return RedirectToAction(nameof(Index));
        }

        private async Task<ProductViewModel> GetProduct (Guid id)
        {
            var product = _mapper.Map<ProductViewModel>(await _productRepository.GetProductAndSupplier(id));
            product.Suppliers = _mapper.Map<IEnumerable<SupplierViewModel>>(await _supplierRepository.GetAll());
            return product;
        }

        private async Task<ProductViewModel> SeedSuppliers(ProductViewModel product)
        {
            product.Suppliers = _mapper.Map<IEnumerable<SupplierViewModel>>(await _supplierRepository.GetAll()); ;
            return product;
        }

        private async Task<bool> UploadFile(IFormFile file, string imgPrefix)
        {
            
            if (file.Length <= 0) return false;

            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", imgPrefix + file.FileName);
        
            if(System.IO.File.Exists(path))
            {
                ModelState.AddModelError(string.Empty, "Já existe um arquivo com esse nome");
                return false;
            }

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            return true;
        }

        private static void DeleteFile(string file)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", file);

            if (System.IO.File.Exists(path))
            {
               System.IO.File.Delete(path);
            }
        }
    }
}

