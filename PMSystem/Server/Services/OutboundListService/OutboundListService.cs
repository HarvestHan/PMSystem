using PMSystem.Server.DataBase;
using PMSystem.Shared;
using PMSystem.Shared.Models;

namespace PMSystem.Server.Services.OutboundListService
{
    /// <summary>
    /// 出库单Service
    /// </summary>
    public class OutboundListService:IOutboundListService
    {
        private IMapper _mapper;
        private OutboundListRepository _outboundListRepository;
        private StorageInfoRepository _storageInfoRepository;
        private IUserService _userService;
        private UserRepository _userRepository;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="repository"></param>
        /// <param name="storageInfoRepository"></param>
        /// <param name="userService"></param>
        /// <param name="userRepository"></param>
        public OutboundListService(IMapper mapper, OutboundListRepository repository, StorageInfoRepository storageInfoRepository ,IUserService userService, UserRepository userRepository)
        {
            this._mapper = mapper;
            this._outboundListRepository = repository;
            this._storageInfoRepository = storageInfoRepository;
            this._userService = userService;
            this._userRepository = userRepository;
        }

        /// <summary>
        /// 获取所有出库单信息
        /// </summary>
        /// <returns></returns>
        public async Task<ServiceResponse<List<OutboundListModel>>> GetOutboundLists()
        {
            var response = new ServiceResponse<List<OutboundListModel>>();
            try
            {
                var list = _mapper.Map<List<OutboundList>, List<OutboundListModel>>(await _outboundListRepository.GetListNavAsync());
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
		/// 添加出库单
		/// </summary>
		/// <param name="outboundListModel"></param>
		/// <returns></returns>
        public async Task<ServiceResponse<string>> AddOutboundList(AddOutboundListModel outboundListModel)
        {
            var response = new ServiceResponse<string>();
            //转为OutboundList，再插入
            OutboundList outboundList = _mapper.Map<AddOutboundListModel, OutboundList>(outboundListModel);
            if (await _outboundListRepository.InsertNavAsync(outboundList))
            {
                //成功
                response.Success = true;
                response.Message = "添加出库单成功!";
            }
            else
            {
                //失败
                response.Success = false;
                response.Message = "添加出库单失败";
            }
            //返回结果
            return response;
        }

        /// <summary>
		/// 通过ID删除出库单
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		/// <exception cref="NotImplementedException"></exception>
		public async Task<ServiceResponse<string>> DeleteOutboundListByID(int id)
        {
            var response = new ServiceResponse<string>();
            try
            {
                if (await _outboundListRepository.DeleteByIdAsync(id))
                {
                    response.Success = true;
                    response.Message = "删除出库单成功";
                }
                else
                {
                    response.Message = "删除出库单失败";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        /// <summary>
        /// 更新出库单信息
        /// </summary>
        /// <param name="outboundListModel"></param>
        /// <returns></returns>
        public async Task<ServiceResponse<string>> UpdateOutboundList(UpdateOutboundListModel outboundListModel)
        {
            var response = new ServiceResponse<string>();
            //转为OutboundList
            OutboundList outboundList = _mapper.Map<UpdateOutboundListModel, OutboundList>(outboundListModel);
            if (await _outboundListRepository.UpdateAsync(outboundList))
            {
                //成功
                response.Success = true;
                response.Message = "更新出库单成功";
            }
            else
            {
                //失败
                response.Success = false;
                response.Message = "更新出库单失败";
            }
            //返回结果
            return response;
        }

        /// <summary>
        /// 更新零件存储数量信息
        /// </summary>
        /// <returns></returns>
        public async Task<ServiceResponse<string>> UpdateQuantity(OutboundListModel outboundListModel)
        {
            var response = new ServiceResponse<string>();
            int Wno = outboundListModel.warehouse_.id;
            int Pno = outboundListModel.parts_.id;
            int quantity = outboundListModel.count;

            StorageInfo storageInfo = await _storageInfoRepository.GetNavByIDAsync(Wno, Pno);
            try
            {
                storageInfo.count -= quantity;
                if (await _storageInfoRepository.UpdateAsync(storageInfo))
                {
                    //成功
                    response.Success = true;
                    response.Message = "出库成功";
                }
                else
                {
                    //失败
                    response.Success = false;
                    response.Message = "出库失败";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
