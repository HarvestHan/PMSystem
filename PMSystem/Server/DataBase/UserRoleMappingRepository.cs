namespace PMSystem.Server.DataBase
{
    public class UserRoleMappingRepository : SimpleClient<UserRoleMapping>
    {
        public UserRoleMappingRepository(ISqlSugarClient context) : base(context)
        {
            this.Context = context;
        }

        public async Task<bool> DeleteRole(int userID, int roleID)
        {
            var mapping = new UserRoleMapping() { user_id = userID, role_id = roleID };
            return await this.Context.Deleteable(mapping).ExecuteCommandAsync() > 0;
        }

        public async Task<bool> InsertNavAsync(int userID, int roleID)
        {
            var mapping = new UserRoleMapping() { user_id = userID, role_id = roleID };
            return await this.Context.Insertable(mapping).ExecuteCommandAsync() > 0;
        }
    }
}
