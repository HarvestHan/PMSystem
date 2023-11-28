namespace PMSystem.Server.Profiles
{
    /// <summary>
    /// 用户Profile
    /// </summary>
    public class UserProfile:Profile
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public UserProfile()
        {
            CreateMap<User, UserModel>();
            CreateMap<UserModel, User>();
            CreateMap<SimpleUserModel, User>();
            CreateMap<User, SimpleUserModel>();
            CreateMap<AddUserModel, User>();
            CreateMap<UpdateUserModel, User>();
        }
    }
}
