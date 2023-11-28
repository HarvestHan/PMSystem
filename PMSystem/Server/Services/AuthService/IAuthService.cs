using PMSystem.Shared;

namespace PMSystem.Server.Services.AuthService
{
    /// <summary>
    /// 身份验证服务接口
    /// </summary>
    public interface IAuthService
    {
        /// <summary>
        /// 登陆
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Task<ServiceResponse<string>> Login(string username,string password);
        
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<ServiceResponse<string>> ChangePassword(ChangePasswordModel model);
        /// <summary>
        /// 获取用户ID
        /// </summary>
        /// <returns></returns>
        int GetUserID();

        string EncryptPassword(string rawPassword);

        Task<ServiceResponse<LoginInfoModel>> GetLoginInfo();
    }
}
