using AutoMapper;
using PMSystem.Shared.Models;

namespace PMSystem.Client.Profiles
{
    public class InboundListProfile:Profile
    {
        public InboundListProfile()
        {
            CreateMap<InboundListModel, InboundListModel>();
            CreateMap<InboundListModel, AddInboundListModel>();
            CreateMap<InboundListModel, UpdateInboundListModel>();
            CreateMap<UpdateInboundListModel, InboundListModel>();
        }
    }
}
