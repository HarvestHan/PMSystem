using PMSystem.Shared;
using PMSystem.Shared.Models;
using System.Net.Http.Json;

namespace PMSystem.Client.Services.AuthService
{
    public class AuthService : IAuthService
    {
        HttpClient httpClient;
        public AuthService(HttpClient client)
        {
            httpClient = client;
        }
        //登录
        public async Task<ServiceResponse<string>> Login(LoginModel request)
        {
            var response = new ServiceResponse<string>();
            try
            {
                //以Json格式请求接口
                var result = await httpClient.PostAsJsonAsync("api/auth/login", request);

                response = await result.Content.ReadFromJsonAsync<ServiceResponse<string>>();
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        //修改密码
        public async Task<ServiceResponse<string>> ChangePassword(ChangePasswordModel request)
        {
            var response = new ServiceResponse<string>();
            try
            {
                //以Json格式请求接口
                var result = await httpClient.PostAsJsonAsync("api/auth/changepassword", request);
                response = await result.Content.ReadFromJsonAsync<ServiceResponse<string>>();
            }
            catch
            {
                response.Success = false;
                response.Message = "请求失败,请检查网络状态!";
            }
            return response;
        }

        public async Task<ServiceResponse<LoginInfoModel>> GetLoginInfo()
        {
            return await httpClient.GetFromJsonAsync<ServiceResponse<LoginInfoModel>>("api/auth/loginInfo");
        }
    }
}
