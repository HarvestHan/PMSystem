using PMSystem.Shared;
using PMSystem.Shared.Models;

namespace PMSystem.Client.Services.AuthService
{
    public interface IAuthService
    {
        Task<ServiceResponse<string>> Login(LoginModel request);
        Task<ServiceResponse<string>> ChangePassword(ChangePasswordModel request);

        Task<ServiceResponse<LoginInfoModel>> GetLoginInfo();
    }
}
