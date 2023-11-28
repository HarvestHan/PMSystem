using AutoMapper;
using PMSystem.Shared.Models;

namespace PMSystem.Client.Profiles
{
    public class UserModelProfile:Profile
    {
        public UserModelProfile()
        {
            CreateMap<UserModel, SimpleUserModel>();
            CreateMap<SimpleUserModel, UserModel>();
            CreateMap<UserModel, AddUserModel>();
            CreateMap<UserModel, UpdateUserModel>();
            CreateMap<UpdateUserModel, UserModel>();
        }
    }
}
