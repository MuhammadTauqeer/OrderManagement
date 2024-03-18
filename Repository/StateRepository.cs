using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class StateRepository : RepositoryBase<State>, IStateRepository
    {
        public StateRepository(RepositoryContext repositoryContext)
        : base(repositoryContext) { }

        public IEnumerable<State> GetAllStates()
        {
            return FindAll().OrderBy(s => s.Name).ToList();
        }

        public State GetStateById(Guid stateId)
        {
            return FindByCondition(s => s.Id.Equals(stateId)).FirstOrDefault();
        }
    }
}

