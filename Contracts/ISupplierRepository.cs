using Entities.Models;
using System;
using System.Collections.Generic;

namespace Contracts
{
    public interface ISupplierRepository : IRepositoryBase<Supplier>
    {
        IEnumerable<Supplier> GetAllSuppliers();
        Supplier GetSupplierById(Guid supplierId);
        void CreateSupplier(Supplier  supplier);
        void UpdateSupplier(Supplier supplier);
        void DeleteSupplier(Supplier supplier);
    }
}
