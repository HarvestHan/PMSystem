namespace PMSystem.Server.Services.CheckListService
{
    public interface ICheckListService
    {
        //获取盘点单
        Task<ServiceResponse<List<CheckListModel>>> GetCheckLists();

        //添加盘点单
        Task<ServiceResponse<string>> AddCheckList(AddCheckListModel checkListModel);

        //更新盘点单
        Task<ServiceResponse<string>> UpdateCheckList(UpdateCheckListModel checkListModel);

        //删除盘点单
        Task<ServiceResponse<string>> DeleteCheckListByID(int id);
    }
}
