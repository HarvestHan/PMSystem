using PMSystem.Shared;
using System.Net.Http.Json;

namespace PMSystem.Client.Services.OutboundListService
{
    public class OutboundListService:IOutboundListService
    {
        HttpClient httpClient;
        public OutboundListService(HttpClient client)
        {
            httpClient = client;
        }

        public async Task<ServiceResponse<List<OutboundListModel>>> GetOutboundLists()
        {
            return await httpClient.GetFromJsonAsync<ServiceResponse<List<OutboundListModel>>>("api/OutboundList/all");
        }

        public async Task<ServiceResponse<string>> AddOutboundList(AddOutboundListModel outboundList)
        {
            var result = await httpClient.PostAsJsonAsync("api/OutboundList/add", outboundList);
            return await result.Content.ReadFromJsonAsync<ServiceResponse<string>>();
        }

        public async Task<ServiceResponse<string>> DeleteOutboundList(int id)
        {
            var result = await httpClient.DeleteAsync($"api/OutboundList/delete?id={id}");
            return await result.Content.ReadFromJsonAsync<ServiceResponse<string>>();
        }

        public async Task<ServiceResponse<string>> UpdateOutboundList(UpdateOutboundListModel outboundList)
        {
            var response = await httpClient.PutAsJsonAsync("api/OutboundList/update", outboundList);
            return await response.Content.ReadFromJsonAsync<ServiceResponse<string>>();
        }

        public async Task<ServiceResponse<string>> UpdateQuantity(OutboundListModel outboundListModel)
        {
            var response = await httpClient.PutAsJsonAsync($"api/OutboundList/updatequantity", outboundListModel);
            return await response.Content.ReadFromJsonAsync<ServiceResponse<string>>();
        }
    }
}
