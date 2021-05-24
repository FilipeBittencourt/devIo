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
    public class SupplierRepository : BaseRepository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(AppDevIoDbContext context) : base(context) { }

        public async Task<Supplier> GetSupplierAddress(Guid id)
        {
            return await DbContext.Supplier.AsNoTracking()
             .Include(a => a.Address)
             .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<Supplier> GetSupplierProductAddress(Guid id)
        {
                return await DbContext.Supplier.AsNoTracking()
                .Include(a => a.Product)
                .Include(a => a.Address)
                .FirstOrDefaultAsync(a => a.Id == id);
        }
    }
}
