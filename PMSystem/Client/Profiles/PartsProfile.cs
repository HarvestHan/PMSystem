using AutoMapper;
using PMSystem.Shared.Models;

namespace PMSystem.Client.Profiles
{
    public class PartsProfile:Profile
    {
        public PartsProfile()
        {
            CreateMap<PartsModel, PartsModel>();
            CreateMap<PartsModel, AddPartsModel>();
            CreateMap<PartsModel, UpdatePartsModel>();
            CreateMap<PartsModel, SimplePartsModel>();
            CreateMap<SimplePartsModel, PartsModel>();
        }
    }
}
