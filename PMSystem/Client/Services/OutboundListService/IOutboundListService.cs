using PMSystem.Shared;

namespace PMSystem.Client.Services.OutboundListService
{
    public interface IOutboundListService
    {
        Task<ServiceResponse<List<OutboundListModel>>> GetOutboundLists();

        Task<ServiceResponse<string>> AddOutboundList(AddOutboundListModel outboundList);

        Task<ServiceResponse<string>> DeleteOutboundList(int id);

        Task<ServiceResponse<string>> UpdateOutboundList(UpdateOutboundListModel outboundList);

        Task<ServiceResponse<string>> UpdateQuantity(OutboundListModel outboundListModel);
    }
}
