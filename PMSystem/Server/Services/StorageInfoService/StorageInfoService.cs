using PMSystem.Server.DataBase;

namespace PMSystem.Server.Services.StorageInfoService
{
    /// <summary>
    /// 存储Service
    /// </summary>
    public class StorageInfoService:IStorageInfoService
    {
        private IMapper _mapper;
        private StorageInfoRepository _storageInfoRepository;
        private IUserService _userService;
        private UserRepository _userRepository;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="repository"></param>
        /// <param name="userService"></param>
        /// <param name="userRepository"></param>
        public StorageInfoService(IMapper mapper, StorageInfoRepository repository, IUserService userService, UserRepository userRepository)
        {
            this._mapper = mapper;
            this._storageInfoRepository = repository;
            this._userService = userService;
            this._userRepository = userRepository;
        }

        /// <summary>
        /// 获取库内存储信息
        /// </summary>
        /// <returns></returns>
        public async Task<ServiceResponse<List<StorageInfoModel>>> GetStorageInfos()
        {
            var response = new ServiceResponse<List<StorageInfoModel>>();
            try
            {
                var list = _mapper.Map<List<StorageInfo>, List<StorageInfoModel>>(await _storageInfoRepository.GetListNavAsync());
                response.Data = list;
                response.Success = true;
                response.Message = "查询成功";
            }
            catch
            {
                response.Success = false;
                response.Message = "查询失败";
            }
            return response;
        }

        /// <summary>
        /// 获取存储数量
        /// </summary>
        /// <returns></returns>
        public async Task<ServiceResponse<StorageInfoModel>> GetStorageInfo(int Wno,int Pno)
        {
            var response = new ServiceResponse<StorageInfoModel>();
            try
            {
                var list = _mapper.Map<StorageInfo, StorageInfoModel>(await _storageInfoRepository.GetNavByIDAsync(Wno, Pno));
                response.Data = list;
                response.Success = true;
                response.Message = "查询成功";
            }
            catch
            {
                response.Success = false;
                response.Message = "查询失败";
            }
            return response;
        }
    }
}
