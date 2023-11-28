namespace PMSystem.Server.DataBase
{
    public class RoleRepository : MyClient<Role>
    {
        public RoleRepository(ISqlSugarClient context) : base(context)
        {
            this.Context = context;
        }
    }
}
