using PMSystem.Shared;

namespace PMSystem.Client.Services.InboundListService
{
    public interface IInboundListService
    {
        Task<ServiceResponse<List<InboundListModel>>> GetInboundLists();

        Task<ServiceResponse<string>> AddInboundList(AddInboundListModel inboundList);

        Task<ServiceResponse<string>> DeleteInboundList(int id);

        Task<ServiceResponse<string>> UpdateInboundList(UpdateInboundListModel inboundList);

        Task<ServiceResponse<string>> UpdateQuantity(InboundListModel inboundListModel);
    }
}
