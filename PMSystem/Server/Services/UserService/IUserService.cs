using PMSystem.Shared;

namespace PMSystem.Server.Services.UserService
{
    /// <summary>
    /// 用户服务接口
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// 获取所有用户信息
        /// </summary>
        /// <returns></returns>
        Task<ServiceResponse<List<UserModel>>> GetUsers();
        /// <summary>
        /// 通过ID获取用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ServiceResponse<UserModel>> GetUserByID(int id);
        /// <summary>
        /// 通过ID导航查询用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ServiceResponse<UserModel>> GetUserNavByIDAsync(int id);
        /// <summary>
        /// 添加新用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<ServiceResponse<string>> AddUser(AddUserModel user);
        /// <summary>
        /// 更新用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<ServiceResponse<string>> UpdateUser(UpdateUserModel user);
        /// <summary>
        /// 通过ID删除用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ServiceResponse<string>> ChangePwd(List<int> userID);
        Task<ServiceResponse<string>> DeleteUserByID(int id);
        /// <summary>
        /// 通过权限获取用户
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        Task<ServiceResponse<List<UserModel>>> GetUsersByRole(RoleModel role);
        /// <summary>
        /// 通过权限ID获取用户
        /// </summary>
        /// <param name="roleID"></param>
        /// <returns></returns>
        Task<ServiceResponse<List<UserModel>>> GetUsersByRoleID(int roleID);
        /// <summary>
        /// 获取科室所属用户
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>

        Task<ServiceResponse<string>> ChangeUsersPwd(ChangeUsersPwdModel model, string newPassword);
        Task<User> ServerGetUser(int id);

        Task<ServiceResponse<string>> AddRole(int userID, int roleID);
        Task<ServiceResponse<string>> DeleteRole(int userID, int roleID);

        Task<List<User>> ServerGetUsers();
    }
}
