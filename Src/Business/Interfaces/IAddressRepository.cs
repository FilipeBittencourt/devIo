using Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IAddressRepository : IBaseRepository<Address>
    {
        Task<Address> GetAddressBySupplier(Guid supplierId);       
    }
}
