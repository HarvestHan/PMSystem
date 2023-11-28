using PMSystem.Shared;

namespace PMSystem.Client.Services.CheckListService
{
    public interface ICheckListService
    {
        Task<ServiceResponse<List<CheckListModel>>> GetCheckLists();

        Task<ServiceResponse<string>> AddCheckList(AddCheckListModel checkList);

        Task<ServiceResponse<string>> DeleteCheckList(int id);

        Task<ServiceResponse<string>> UpdateCheckList(UpdateCheckListModel checklist);
    }
}
