using AutoMapper.Configuration.Conventions;
using PMSystem.Shared;

namespace PMSystem.Client.Services.StorageInfoService
{
    public interface IStorageInfoService
    {
        Task<ServiceResponse<List<StorageInfoModel>>> GetStorageInfos();

        Task<ServiceResponse<StorageInfoModel>> GetStorageInfo(int Wno,int Pno);
    }
}
