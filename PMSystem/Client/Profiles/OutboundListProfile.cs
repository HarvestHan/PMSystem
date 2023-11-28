using AutoMapper;
using PMSystem.Shared.Models;

namespace PMSystem.Client.Profiles
{
    public class OutboundListProfile:Profile
    {
        public OutboundListProfile()
        {
            CreateMap<OutboundListModel, OutboundListModel>();
            CreateMap<OutboundListModel, AddOutboundListModel>();
            CreateMap<OutboundListModel, UpdateOutboundListModel>();
        }
    }
}
