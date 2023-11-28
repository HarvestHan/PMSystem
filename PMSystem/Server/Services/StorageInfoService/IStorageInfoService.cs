using PMSystem.Server.DataBase;

namespace PMSystem.Server.Services.StorageInfoService
{
    public interface IStorageInfoService
    {
        //获取存储信息
        Task<ServiceResponse<List<StorageInfoModel>>> GetStorageInfos();

        Task<ServiceResponse<StorageInfoModel>> GetStorageInfo(int Wno,int Pno);
    }
}
