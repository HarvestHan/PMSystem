using DocumentFormat.OpenXml.Spreadsheet;
using PMSystem.Shared;
using PMSystem.Shared.Models;
using System.Net.Http;
using System.Net.Http.Json;

namespace PMSystem.Client.Services.UserService
{
    public class UserService : IUserService
    {
        HttpClient _httpClient;
        public UserService(HttpClient client)
        {
            _httpClient = client;
        }
        public async Task<ServiceResponse<string>> AddUser(AddUserModel user)
        {
            var result = await _httpClient.PostAsJsonAsync("api/user/add", user);
            return await result.Content.ReadFromJsonAsync<ServiceResponse<string>>();
        }

        public async Task<ServiceResponse<UserModel>> GetUser()
        {
            return await _httpClient.GetFromJsonAsync<ServiceResponse<UserModel>>($"api/user/getuser");
        }

        public async Task<ServiceResponse<List<UserModel>>> GetUsers()
        {
            var result = await _httpClient.GetFromJsonAsync<ServiceResponse<List<UserModel>>>("api/user/all");
            return result;
        }

        public async Task<ServiceResponse<List<UserModel>>> GetUsersByRoleID(int id)
        {
            return await _httpClient.GetFromJsonAsync<ServiceResponse<List<UserModel>>>($"api/user/getuserbyroleid?roleID={id}");
        }

        public async Task<ServiceResponse<UserModel>> GetLoginUser(int id)
        {
            return await _httpClient.GetFromJsonAsync<ServiceResponse<UserModel>>($"api/user/getusernavbyid&id={id}");
        }

        public async Task<ServiceResponse<string>> UpdateUser(UpdateUserModel user)
        {
            var response = await _httpClient.PutAsJsonAsync("api/user/update", user);
            return await response.Content.ReadFromJsonAsync<ServiceResponse<string>>();
        }

        //通过账号修改用户密码
        public async Task<ServiceResponse<string>> ChangeUsersPwd(ChangeUsersPwdModel model, string newPassword)
        {
            var response = await _httpClient.PostAsJsonAsync($"api/user/changeuserspwd?newPassword={newPassword}", model);
            return await response.Content.ReadFromJsonAsync<ServiceResponse<string>>();
        }

        public async Task<ServiceResponse<string>> ChangePwd(List<int> userID)
        {
            var response = await _httpClient.PostAsJsonAsync($"api/user/changepwd", userID);
            return await response.Content.ReadFromJsonAsync<ServiceResponse<string>>();
        }

        public async Task<ServiceResponse<string>> DeleteUser(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/user/delete?id={id}");
            return await response.Content.ReadFromJsonAsync<ServiceResponse<string>>();
        }

		public async Task<ServiceResponse<string>> AddRole(int userID, int roleID)
		{
            var response = await _httpClient.PutAsync($"api/user/addrole?userID={userID}&roleID={roleID}",null);
			return await response.Content.ReadFromJsonAsync<ServiceResponse<string>>();
		}

		public async Task<ServiceResponse<string>> DeleteRole(int userID, int roleID)
		{
			var response = await _httpClient.PutAsync($"api/user/deleterole?userID={userID}&roleID={roleID}", null);
			return await response.Content.ReadFromJsonAsync<ServiceResponse<string>>();
		}
    }
}
