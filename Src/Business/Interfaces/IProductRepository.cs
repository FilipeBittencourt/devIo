using Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task<IEnumerable<Product>> GetProductWithSupplies();

        Task<IEnumerable<Product>> GetProductBySupplies(Guid supplierId);

        Task<Product> GetProductWithSupplier(Guid id);      

    }
}
