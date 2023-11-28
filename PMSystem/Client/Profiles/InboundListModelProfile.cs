using AutoMapper;
using PMSystem.Shared.Models;

namespace PMSystem.Client.Profiles
{
    public class InboundListModelProfile:Profile
    {
        public InboundListModelProfile()
        {
            CreateMap<InboundListModel, InboundListModel>();
            CreateMap<InboundListModel, AddInboundListModel>();
            CreateMap<InboundListModel, UpdateInboundListModel>();
            CreateMap<UpdateInboundListModel, InboundListModel>();
        }
    }
}
