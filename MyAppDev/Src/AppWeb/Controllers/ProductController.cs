﻿using AppWeb.ViewModels;
using AutoMapper;
using Business.Interfaces;
using Business.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppWeb.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IProductRepository _productRepository;
        private readonly ISupplierRepository _supplierRepository;
        private readonly IMapper _mapper;

        public ProductController(IProductRepository productRepository, IMapper mapper, ISupplierRepository supplierRepository)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _supplierRepository = supplierRepository;
        }


        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<ProductViewModel>>(await _productRepository.GetProductSupplies()));
        }


        public async Task<IActionResult> Details(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ProductViewModel = await GetProductById(id);

            if (ProductViewModel == null)
            {
                return NotFound();
            }

            return View(ProductViewModel);
        }

        // GET: Product/Create
        public async Task<IActionResult> Create()
        {

            var productViewModel = await PopulateSupplier(new ProductViewModel());

            return View(productViewModel);
        }

        // POST: Product/Create        
        [HttpPost]        
        public async Task<IActionResult> Create(ProductViewModel productViewModel)
        {
            productViewModel = await PopulateSupplier(productViewModel);

            if (!ModelState.IsValid)
            {
                return View(productViewModel);
            }
 
            await _productRepository.Create(_mapper.Map<Product>(productViewModel));

            return View(productViewModel);

        }

        // GET: Product/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var productViewModel = await GetProductById(id);

            if (productViewModel == null)
            {
                return NotFound();
            }

            return View(productViewModel);
        }

        // POST: Product/Edit/5 
        [HttpPost]       
        public async Task<IActionResult> Edit(Guid id, ProductViewModel productViewModel)
        {
            if (id != productViewModel.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(productViewModel);
            }

            var product = _mapper.Map<Product>(productViewModel);
            await _productRepository.Update(product);

            return View("Index");
        }

        // GET: Product/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {

            var product = await GetProductById(id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var productViewModel = await GetProductById(id);

            if (productViewModel == null)
            {
                return NotFound();
            }

            var product = _mapper.Map<Product>(productViewModel);
            await _productRepository.Delete(product);

            return RedirectToAction(nameof(Index));
        }

        private async Task<ProductViewModel> GetProductById(Guid id)
        {
            
            var product  = ( _mapper.Map<ProductViewModel>(await _productRepository.GetProductSupplier(id)));
            
            product.Suppliers = ( _mapper.Map<IEnumerable<SupplierViewModel>>(
            await _supplierRepository.
            GetAll()));

            return product;

        }

        private async Task<ProductViewModel> PopulateSupplier(ProductViewModel productView)
        {
            productView.Suppliers = (_mapper.Map<IEnumerable<SupplierViewModel>>(
            await _supplierRepository.
            GetAll()));

            return productView;           

        }
    }
}
