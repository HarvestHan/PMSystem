using PMSystem.Shared;
using PMSystem.Shared.Models;

namespace PMSystem.Client.Services.UserService
{
    public interface IUserService
    {
        Task<ServiceResponse<List<UserModel>>> GetUsers();
        Task<ServiceResponse<string>> AddUser(AddUserModel user);
        Task<ServiceResponse<List<UserModel>>> GetUsersByRoleID(int id);
        Task<ServiceResponse<UserModel>> GetUser();

        Task<ServiceResponse<string>> UpdateUser(UpdateUserModel user);
        Task<ServiceResponse<string>> DeleteUser(int id);

        Task<ServiceResponse<string>> ChangeUsersPwd(ChangeUsersPwdModel model, string newPassword);

        Task<ServiceResponse<string>> ChangePwd(List<int> userID);

        Task<ServiceResponse<string>> AddRole(int userID, int roleID);
        Task<ServiceResponse<string>> DeleteRole(int userID, int roleID);
    }
}
