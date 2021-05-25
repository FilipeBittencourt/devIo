using Business.Models;
using System;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface ISupplierRepository : IBaseRepository<Supplier>
    {
        Task<Supplier> GetSupplierAddress(Guid id);

        Task<Supplier> GetSupplierProductAddress(Guid id);
    }
}
