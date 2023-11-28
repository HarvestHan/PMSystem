using PMSystem.Shared;
using System.Net.Http;
using System.Net.Http.Json;

namespace PMSystem.Client.Services.InboundListService
{
    public class InboundListService:IInboundListService
    {
        HttpClient httpClient;
        public InboundListService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<ServiceResponse<List<InboundListModel>>> GetInboundLists()
        {
            return await httpClient.GetFromJsonAsync<ServiceResponse<List<InboundListModel>>>("api/InboundList/all");
        }

        public async Task<ServiceResponse<string>> AddInboundList(AddInboundListModel inboundList)
        {
            var result = await httpClient.PostAsJsonAsync("api/InboundList/add", inboundList);
            return await result.Content.ReadFromJsonAsync<ServiceResponse<string>>();
        }

        public async Task<ServiceResponse<string>> DeleteInboundList(int id)
        {
            var result = await httpClient.DeleteAsync($"api/InboundList/delete?id={id}");
            return await result.Content.ReadFromJsonAsync<ServiceResponse<string>>();
        }

        public async Task<ServiceResponse<string>> UpdateInboundList(UpdateInboundListModel inboundList)
        {
            var response = await httpClient.PutAsJsonAsync("api/InboundList/update", inboundList);
            return await response.Content.ReadFromJsonAsync<ServiceResponse<string>>();
        }

        public async Task<ServiceResponse<string>> UpdateQuantity(InboundListModel inboundListModel)
        {
            var response = await httpClient.PutAsJsonAsync($"api/InboundList/updatequantity", inboundListModel);
            return await response.Content.ReadFromJsonAsync<ServiceResponse<string>>();
        }
    }
}
