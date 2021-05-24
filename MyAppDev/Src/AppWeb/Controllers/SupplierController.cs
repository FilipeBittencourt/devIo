
using AppWeb.ViewModels;
using AutoMapper;
using Business.Interfaces;
using Business.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppWeb.Controllers
{
    [Authorize]
    public class SupplierController : BaseController
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IMapper _mapper;

        public SupplierController(ISupplierRepository supplierRepository, IMapper mapper)
        {
            _supplierRepository = supplierRepository;
            _mapper = mapper;

        }


        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<SupplierViewModel>>(await _supplierRepository.GetAll()));
        }


        public async Task<IActionResult> Details(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplierViewModel = await GetSupplierAddress(id);

            if (supplierViewModel == null)
            {
                return NotFound();
            }

            return View(supplierViewModel);
        }

        // GET: Supplier/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Supplier/Create        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SupplierViewModel supplierViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(supplierViewModel);
            }

            var supplier = _mapper.Map<Supplier>(supplierViewModel);
            await _supplierRepository.Create(supplier);

            return RedirectToAction("Index");


        }

        // GET: Supplier/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var supplierViewModel = await GetSupplierProductAddress(id);

            if (supplierViewModel == null)
            {
                return NotFound();
            }

            return View(supplierViewModel);
        }

        // POST: Supplier/Edit/5 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, SupplierViewModel supplierViewModel)
        {
            if (id != supplierViewModel.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(supplierViewModel);
            }

            var supplier = _mapper.Map<Supplier>(supplierViewModel);
            await _supplierRepository.Update(supplier);

            return View("Index");
        }

        // GET: Supplier/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {

            var supplierViewModel = await GetSupplierAddress(id);

            if (supplierViewModel == null)
            {
                return NotFound();
            }

            return View(supplierViewModel);
        }

        // POST: Supplier/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var supplierViewModel = await GetSupplierAddress(id);

            if (supplierViewModel == null)
            {
                return NotFound();
            }

            var supplier = _mapper.Map<Supplier>(supplierViewModel);
            await _supplierRepository.Delete(supplier);

            return RedirectToAction(nameof(Index));
        }

        private async Task<SupplierViewModel> GetSupplierAddress(Guid id)
        {
            return (_mapper.Map<SupplierViewModel>(await _supplierRepository.GetSupplierAddress(id)));

        }

        private async Task<SupplierViewModel> GetSupplierProductAddress(Guid id)
        {
            return (_mapper.Map<SupplierViewModel>(await _supplierRepository.GetSupplierProductAddress(id)));

        }
    }
}
