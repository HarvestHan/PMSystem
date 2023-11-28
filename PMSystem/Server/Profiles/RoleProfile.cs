namespace PMSystem.Server.Profiles
{
    public class RoleProfile:Profile
    {
        public RoleProfile()
        {
            CreateMap<Role, RoleModel>();
            CreateMap<RoleModel, Role>();
        }
    }
}
