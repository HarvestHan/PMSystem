using AutoMapper;
using PMSystem.Shared.Models;

namespace PMSystem.Client.Profiles
{
    public class CheckListProfile:Profile
    {
        public CheckListProfile()
        {
            CreateMap<CheckListModel, CheckListModel>();
            CreateMap<CheckListModel, AddCheckListModel>();
            CreateMap<CheckListModel, UpdateCheckListModel>();
        }
    }
}
