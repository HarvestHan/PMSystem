using PMSystem.Shared;
using PMSystem.Shared.Models;
using System.Net.Http.Json;

namespace PMSystem.Client.Services.WarehouseService
{
    public class WarehouseService:IWarehouseService
    {
        HttpClient httpClient;
        public WarehouseService(HttpClient client)
        {
            httpClient = client;
        }

        public async Task<ServiceResponse<List<WarehouseModel>>> GetWarehouses()
        {
            return await httpClient.GetFromJsonAsync<ServiceResponse<List<WarehouseModel>>>("api/Warehouse/all");
        }

        public async Task<ServiceResponse<string>> AddWarehouse(AddWarehouseModel warehouse)
        {
            var result = await httpClient.PostAsJsonAsync("api/Warehouse/add", warehouse);
            return await result.Content.ReadFromJsonAsync<ServiceResponse<string>>();
        }

        public async Task<ServiceResponse<string>> DeleteWarehouse(int id)
        {
            var result = await httpClient.DeleteAsync($"api/Warehouse/delete?id={id}");
            return await result.Content.ReadFromJsonAsync<ServiceResponse<string>>();
        }

        public async Task<ServiceResponse<string>> UpdateWarehouse(UpdateWarehouseModel warehouse)
        {
            var response = await httpClient.PutAsJsonAsync("api/Warehouse/update", warehouse);
            return await response.Content.ReadFromJsonAsync<ServiceResponse<string>>();
        }
    }
}
