
using PMSystem.Shared;
using PMSystem.Shared.Models;
using System.Net.Http.Json;

namespace PMSystem.Client.Services.RoleService
{
    public class RoleService : IRoleService
    {
        HttpClient httpClient;
        public RoleService(HttpClient client)
        {
            this.httpClient = client;   
        }
        public async Task<ServiceResponse<List<RoleModel>>> GetRoles()
        {
            return await httpClient.GetFromJsonAsync<ServiceResponse<List<RoleModel>>>("api/role/all");
        }

        public async Task<ServiceResponse<List<RoleModel>>> GetRolesByUserID(int userID)
        {
            return await httpClient.GetFromJsonAsync<ServiceResponse<List<RoleModel>>>($"api/role/rolesbyuserid?userID={userID}");
        }
    }
}
