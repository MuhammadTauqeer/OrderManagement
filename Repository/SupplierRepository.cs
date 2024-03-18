using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class SupplierRepository : RepositoryBase<Supplier>, ISupplierRepository
    {
        public SupplierRepository(RepositoryContext repositoryContext)
        : base(repositoryContext) { }

        public IEnumerable<Supplier> GetAllSuppliers()
        {
            return FindAll()
                .OrderBy(s => s.Name)
                .ToList();
        }

        public Supplier GetSupplierById(Guid supplierId)
        {
            //return  RepositoryContext.Suppliers.Include(s=>s.State).Where(x =>x.Id.Equals(supplierId)).SingleOrDefault();

            return FindByCondition(s => s.Id.Equals(supplierId)).Include(s => s.State)
                    .FirstOrDefault();
        }

        public void CreateSupplier(Supplier supplier) => Create(supplier);

        public void UpdateSupplier(Supplier supplier)
        {
            var foundSupplier = RepositoryContext.Suppliers.FirstOrDefault(e => e.Id == supplier.Id);

            if (foundSupplier != null)
            {
                foundSupplier.StateId = supplier.StateId;
                foundSupplier.Name = supplier.Name;
                foundSupplier.AddressLine1 = supplier.AddressLine1;
                foundSupplier.AddressLine2 = supplier.AddressLine2;
                foundSupplier.City = supplier.City;
                foundSupplier.PostalCode = supplier.PostalCode;


                RepositoryContext.SaveChanges();

            }
        }

            public void DeleteSupplier(Supplier supplier) => Delete(supplier);
    }
}

