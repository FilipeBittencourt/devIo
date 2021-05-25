using Business.Interfaces;
using Business.Models;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
namespace Data.Repository
{
    public class AddressRepository : BaseRepository<Address>, IAddressRepository
    {
        public AddressRepository(AppDevIoDbContext context) : base(context) { }

        public async Task<Address> GetAddressBySupplier(Guid supplierId)
        {
            return await DbContext.Address.AsNoTracking()
             .FirstOrDefaultAsync(p => p.SupplierId == supplierId);
        }
    }
}
