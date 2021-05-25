using Business.Interfaces;
using Business.Models;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDevIoDbContext context) :base(context) { }


        public async Task<Product> GetProductSupplier(Guid id)
        {
            return await DbContext.Product.AsNoTracking().Include(f => f.Supplier)
               .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Product>> GetProductSupplies()
        {
            return await DbContext.Product.AsNoTracking().Include(f => f.Supplier)
                .OrderBy(p => p.Name).ToListAsync();

        }

        public async Task<IEnumerable<Product>> GetProductBySupplies(Guid supplierId)
        {
            return await List(p => p.SupplierId == supplierId);

        }
    }
}
