using AutoMapper;

namespace PMSystem.Server.Profiles
{
    /// <summary>
    /// 存储信息Profile
    /// </summary>
    public class StorageInfoProfile:Profile
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public StorageInfoProfile()
        {
            CreateMap<StorageInfoModel, StorageInfo>();
            CreateMap<StorageInfo,StorageInfoModel>();
        }
    }
}
