using PMSystem.Shared;
using System.Net.Http;
using System.Net.Http.Json;

namespace PMSystem.Client.Services.TransferListService
{
    public class TransferListService:ITransferListService
    {
        HttpClient httpClient;
        public TransferListService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<ServiceResponse<List<TransferListModel>>> GetTransferLists()
        {
            return await httpClient.GetFromJsonAsync<ServiceResponse<List<TransferListModel>>>("api/TransferList/all");
        }

        public async Task<ServiceResponse<string>> AddTransferList(AddTransferListModel transferList)
        {
            var result = await httpClient.PostAsJsonAsync("api/TransferList/add", transferList);
            return await result.Content.ReadFromJsonAsync<ServiceResponse<string>>();
        }

        public async Task<ServiceResponse<string>> Transfer(List<int> list)
        {
            var response = await httpClient.PostAsJsonAsync("api/TransferList/transfer", list);
            return await response.Content.ReadFromJsonAsync<ServiceResponse<string>>();
        }

        public async Task<ServiceResponse<string>> DeleteTransferList(int id)
        {
            var result = await httpClient.DeleteAsync($"api/TransferList/delete?id={id}");
            return await result.Content.ReadFromJsonAsync<ServiceResponse<string>>();
        }

        public async Task<ServiceResponse<string>> UpdateTransferList(UpdateTransferListModel transferList)
        {
            var response = await httpClient.PutAsJsonAsync("api/TransferList/update", transferList);
            return await response.Content.ReadFromJsonAsync<ServiceResponse<string>>();
        }
    }
}
