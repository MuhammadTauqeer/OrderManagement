using Entities.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace OrderManagementUI.Services
{
    public class StateService : IStateService
    {
        private readonly HttpClient _httpClient;

        public StateService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<State>> GetAllStates()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<State>>
                (await _httpClient.GetStreamAsync($"api/state"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<State> GetStateById(int StateId)
        {
            return await JsonSerializer.DeserializeAsync<State>
                (await _httpClient.GetStreamAsync($"api/State{StateId}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
    }
}
