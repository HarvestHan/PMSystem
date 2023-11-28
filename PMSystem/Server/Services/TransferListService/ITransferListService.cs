namespace PMSystem.Server.Services.TransferListService
{
    public interface ITransferListService
    {
        //获取调拨单
        Task<ServiceResponse<List<TransferListModel>>> GetTransferLists();

        //添加调拨单
        Task<ServiceResponse<string>> AddTransferList(AddTransferListModel transferListModel);

        //删除调拨单
        Task<ServiceResponse<string>> DeleteTransferListByID(int id);

        //更新调拨单
        Task<ServiceResponse<string>> UpdateTransferList(UpdateTransferListModel transferListModel);

        //调拨更新
        Task<ServiceResponse<string>> Transfer(List<int> list);
    }
}
