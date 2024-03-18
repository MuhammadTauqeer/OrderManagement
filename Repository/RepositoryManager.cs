using Contracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private RepositoryContext _repositoryContext;
        private ISupplierRepository _supplierRepository;
        private IStateRepository _stateRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        { 
            _repositoryContext = repositoryContext; }
        public ISupplierRepository Supplier
        {
            get
            {
                if (_supplierRepository == null) 
                    _supplierRepository = new SupplierRepository(_repositoryContext);
                return _supplierRepository;
            }
        }
        public IStateRepository State 
        { 
            get 
            { 
                if (_stateRepository == null) 
                    _stateRepository = new StateRepository(_repositoryContext); 
                return _stateRepository; } }
        public void Save() => _repositoryContext.SaveChanges();
    }
}
