using PMSystem.Shared;
using PMSystem.Shared.Models;

namespace PMSystem.Client.Services.RoleService
{
    public interface IRoleService
    {
        Task<ServiceResponse<List<RoleModel>>> GetRoles();
        Task<ServiceResponse<List<RoleModel>>> GetRolesByUserID(int userID);
    }
}
