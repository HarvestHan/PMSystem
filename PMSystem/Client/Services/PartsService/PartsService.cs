using PMSystem.Shared;
using System.Net.Http.Json;

namespace PMSystem.Client.Services.PartsService
{
    public class PartsService:IPartsService
    {
        HttpClient httpClient;
        public PartsService(HttpClient client)
        {
            httpClient = client;
        }

        public async Task<ServiceResponse<List<PartsModel>>> GetParts()
        {
            return await httpClient.GetFromJsonAsync<ServiceResponse<List<PartsModel>>>("api/Parts/all");
        }

        public async Task<ServiceResponse<string>> AddParts(AddPartsModel parts)
        {
            var result = await httpClient.PostAsJsonAsync("api/Parts/add", parts);
            return await result.Content.ReadFromJsonAsync<ServiceResponse<string>>();
        }

        public async Task<ServiceResponse<string>> DeleteParts(int id)
        {
            var result = await httpClient.DeleteAsync($"api/Parts/delete?id={id}");
            return await result.Content.ReadFromJsonAsync<ServiceResponse<string>>();
        }

        public async Task<ServiceResponse<string>> UpdateParts(UpdatePartsModel parts)
        {
            var response = await httpClient.PutAsJsonAsync("api/Parts/update", parts);
            return await response.Content.ReadFromJsonAsync<ServiceResponse<string>>();
        }
    }
}
