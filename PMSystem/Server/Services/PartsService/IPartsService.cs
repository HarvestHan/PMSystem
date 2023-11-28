namespace PMSystem.Server.Services.PartsService
{
    public interface IPartsService
    {
        //获取零件
        Task<ServiceResponse<List<PartsModel>>> GetParts();

        //添加零件
        Task<ServiceResponse<string>> AddParts(AddPartsModel partsModel);

        //更新零件
        Task<ServiceResponse<string>> UpdateParts(UpdatePartsModel partsModel);
        //删除
        Task<ServiceResponse<string>> DeletePartsByID(int id);
    }
}
