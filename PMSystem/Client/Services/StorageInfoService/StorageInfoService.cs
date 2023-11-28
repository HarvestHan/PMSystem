using PMSystem.Shared;
using PMSystem.Shared.Models;
using System.Net.Http.Json;

namespace PMSystem.Client.Services.StorageInfoService
{
    public class StorageInfoService:IStorageInfoService
    {
        HttpClient httpClient;
        public StorageInfoService(HttpClient client)
        {
            httpClient = client;
        }

        public async Task<ServiceResponse<List<StorageInfoModel>>> GetStorageInfos()
        {
            return await httpClient.GetFromJsonAsync<ServiceResponse<List<StorageInfoModel>>>("api/StorageInfo/all");
        }

        public async Task<ServiceResponse<StorageInfoModel>> GetStorageInfo(int Wno,int Pno)
        {
            return await httpClient.GetFromJsonAsync<ServiceResponse<StorageInfoModel>>($"api/StorageInfo/one?Wno={Wno}&Pno={Pno}");
        }
    }
}
