using Entities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrderManagementUI.Services
{
    public interface IStateService
    {
        Task<IEnumerable<State>> GetAllStates();
        Task<State> GetStateById(int countryId);
    }
}
