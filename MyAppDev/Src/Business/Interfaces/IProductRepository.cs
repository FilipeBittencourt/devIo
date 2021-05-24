using Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task<Product> GetProductSupplier(Guid id);

        Task<IEnumerable<Product>> GetProductSupplies();

        Task<IEnumerable<Product>> GetProductBySupplies(Guid supplierId);

        
    }
}
