using PMSystem.Shared;
using System.Net.Http.Json;

namespace PMSystem.Client.Services.CheckListService
{
    public class CheckListService:ICheckListService
    {
        HttpClient httpClient;
        public CheckListService(HttpClient client)
        {
            httpClient = client;
        }

        public async Task<ServiceResponse<List<CheckListModel>>> GetCheckLists()
        {
            return await httpClient.GetFromJsonAsync<ServiceResponse<List<CheckListModel>>>("api/CheckList/all");
        }

        public async Task<ServiceResponse<string>> AddCheckList(AddCheckListModel checkList)
        {
            var result = await httpClient.PostAsJsonAsync("api/CheckList/add", checkList);
            return await result.Content.ReadFromJsonAsync<ServiceResponse<string>>();
        }

        public async Task<ServiceResponse<string>> DeleteCheckList(int id)
        {
            var result = await httpClient.DeleteAsync($"api/CheckList/delete?id={id}");
            return await result.Content.ReadFromJsonAsync<ServiceResponse<string>>();
        }

        public async Task<ServiceResponse<string>> UpdateCheckList(UpdateCheckListModel checkList)
        {
            var response = await httpClient.PutAsJsonAsync("api/CheckList/update", checkList);
            return await response.Content.ReadFromJsonAsync<ServiceResponse<string>>();
        }
    }
}
