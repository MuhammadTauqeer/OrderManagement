using Entities.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrderManagementUI.Services
{
    public interface ISupplierService
    {
        Task<IEnumerable<Supplier>> GetAllSuppliers();
        Task<Supplier> GetSupplierDetails(Guid supplierId);
        Task<Supplier> AddSupplier(Supplier supplier);
        Task UpdateSupplier(Supplier supplier);
        Task DeleteSupplier(Guid supplierId);
    }
}
