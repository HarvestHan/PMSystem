namespace PMSystem.Server.Services.OutboundListService
{
    public interface IOutboundListService
    {
        //获取出库单
        Task<ServiceResponse<List<OutboundListModel>>> GetOutboundLists();

        //添加出库单
        Task<ServiceResponse<string>> AddOutboundList(AddOutboundListModel outboundListModel);

        //更新出库单
        Task<ServiceResponse<string>> UpdateOutboundList(UpdateOutboundListModel outboundListModel);

        //删除出库单
        Task<ServiceResponse<string>> DeleteOutboundListByID(int id);

        //更新零件数量信息
        Task<ServiceResponse<string>> UpdateQuantity(OutboundListModel outboundListModel);
    }
}
