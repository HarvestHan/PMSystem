using PMSystem.Shared;

namespace PMSystem.Client.Services.TransferListService
{
    public interface ITransferListService
    {
        Task<ServiceResponse<List<TransferListModel>>> GetTransferLists();

        Task<ServiceResponse<string>> AddTransferList(AddTransferListModel transferList);

        Task<ServiceResponse<string>> DeleteTransferList(int id);

        Task<ServiceResponse<string>> UpdateTransferList(UpdateTransferListModel transferList);

        Task<ServiceResponse<string>> Transfer(List<int> list);
    }
}
