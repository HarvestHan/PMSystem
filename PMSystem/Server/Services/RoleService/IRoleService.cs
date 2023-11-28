namespace PMSystem.Server.Services.RoleService
{
    public interface IRoleService
    {
        Task<ServiceResponse<List<RoleModel>>> GetRoles();
        Task<ServiceResponse<RoleModel>> GetRole(int id);
        Task<ServiceResponse<List<RoleModel>>> GetRolesByUserID(int userID);
    }
}
