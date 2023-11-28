namespace PMSystem.Server.Services.InboundListService
{
    public interface IInboundListService
    {
        //获取入库单
        Task<ServiceResponse<List<InboundListModel>>> GetInboundLists();

        //添加入库单
        Task<ServiceResponse<string>> AddInboundList(AddInboundListModel inboundListModel);

        //更新入库单
        Task<ServiceResponse<string>> UpdateInboundList(UpdateInboundListModel inboundListModel);

        //删除入库单
        Task<ServiceResponse<string>> DeleteInboundListByID(int id);

        //更新零件数量信息
        Task<ServiceResponse<string>> UpdateQuantity(InboundListModel inboundListModel);
    }
}
