using AutoMapper;
using PMSystem.Shared.Models;

namespace PMSystem.Client.Profiles
{
    public class TransferListProfile : Profile
    {
        public TransferListProfile()
        {
            CreateMap<TransferListModel, TransferListModel>();
            CreateMap<TransferListModel, AddTransferListModel>();
            CreateMap<TransferListModel, UpdateTransferListModel>();
        }
    }
}
