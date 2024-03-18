using Entities.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace OrderManagementUI.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly HttpClient _httpClient;

        public SupplierService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Supplier> AddSupplier(Supplier supplier)
        {
            var supplierJson =
                new StringContent(JsonSerializer.Serialize(supplier), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/supplier", supplierJson);

            if (response.IsSuccessStatusCode)
            {
                return await JsonSerializer.DeserializeAsync<Supplier>(await response.Content.ReadAsStreamAsync());
            }

            return null;
        }

        public async Task UpdateSupplier(Supplier supplier)
        {
            var supplierJson =
                new StringContent(JsonSerializer.Serialize(supplier), Encoding.UTF8, "application/json");

            await _httpClient.PutAsync("api/supplier", supplierJson);
        }

        public async Task DeleteSupplier(Guid supplierId)
        {
            await _httpClient.DeleteAsync($"api/supplier/{supplierId}");
        }

        public async Task<IEnumerable<Supplier>> GetAllSuppliers()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<Supplier>>
                    (await _httpClient.GetStreamAsync($"api/supplier"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<Supplier> GetSupplierDetails(Guid supplierId)
        {
            return await JsonSerializer.DeserializeAsync<Supplier>
                (await _httpClient.GetStreamAsync($"api/supplier/{supplierId}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }


    }
}

