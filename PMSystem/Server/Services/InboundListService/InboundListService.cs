using PMSystem.Server.DataBase;
using PMSystem.Shared;
using PMSystem.Shared.Models;
using Ubiety.Dns.Core;

namespace PMSystem.Server.Services.InboundListService
{
    /// <summary>
    /// 入库单Service
    /// </summary>
    public class InboundListService:IInboundListService
    {
        private IMapper _mapper;
        private InboundListRepository _inboundListRepository;
        private StorageInfoRepository _storageInfoRepository;
        private IStorageInfoService _storageInfoService;
        private IUserService _userService;
        private UserRepository _userRepository;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="repository"></param>
        /// <param name="storageInfoRepository"></param>
        /// <param name="storageInfoService"></param>
        /// <param name="userService"></param>
        /// <param name="userRepository"></param>
        public InboundListService(IMapper mapper, InboundListRepository repository, StorageInfoRepository storageInfoRepository ,IStorageInfoService storageInfoService,IUserService userService, UserRepository userRepository)
        {
            this._mapper = mapper;
            this._inboundListRepository = repository;
            this._storageInfoRepository = storageInfoRepository;
            this._storageInfoService = storageInfoService;
            this._userService = userService;
            this._userRepository = userRepository;
        }

        /// <summary>
        /// 获取所有入库单信息
        /// </summary>
        /// <returns></returns>
        public async Task<ServiceResponse<List<InboundListModel>>> GetInboundLists()
        {
            var response = new ServiceResponse<List<InboundListModel>>();
            try
            {
                var list = _mapper.Map<List<InboundList>, List<InboundListModel>>(await _inboundListRepository.GetListNavAsync());
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
		/// 添加入库单
		/// </summary>
		/// <param name="inboundListModel"></param>
		/// <returns></returns>
        public async Task<ServiceResponse<string>> AddInboundList(AddInboundListModel inboundListModel)
        {
            var response = new ServiceResponse<string>();
            //转为InboundList，再插入
            InboundList inboundList = _mapper.Map<AddInboundListModel, InboundList>(inboundListModel);
            if (await _inboundListRepository.InsertNavAsync(inboundList))
            {
                //成功
                response.Success = true;
                response.Message = "添加入库单成功!";
            }
            else
            {
                //失败
                response.Success = false;
                response.Message = "添加入库单失败";
            }
            //返回结果
            return response;
        }

        /// <summary>
		/// 通过ID删除入库单
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		/// <exception cref="NotImplementedException"></exception>
		public async Task<ServiceResponse<string>> DeleteInboundListByID(int id)
        {
            var response = new ServiceResponse<string>();
            try
            {
                if (await _inboundListRepository.DeleteByIdAsync(id))
                {
                    response.Success = true;
                    response.Message = "删除入库单成功";
                }
                else
                {
                    response.Message = "删除入库单失败";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        /// <summary>
        /// 更新入库单信息
        /// </summary>
        /// <param name="inboundListModel"></param>
        /// <returns></returns>
        public async Task<ServiceResponse<string>> UpdateInboundList(UpdateInboundListModel inboundListModel)
        {
            var response = new ServiceResponse<string>();
            //转为InboundList
            InboundList inboundList = _mapper.Map<UpdateInboundListModel, InboundList>(inboundListModel);
            if (await _inboundListRepository.UpdateAsync(inboundList))
            {
                //成功
                response.Success = true;
                response.Message = "更新入库单成功";
            }
            else
            {
                //失败
                response.Success = false;
                response.Message = "更新入库单失败";
            }
            //返回结果
            return response;
        }

        /// <summary>
        /// 更新零件存储数量信息
        /// </summary>
        /// <returns></returns>
        public async Task<ServiceResponse<string>> UpdateQuantity(InboundListModel inboundListModel)
        {
            var response = new ServiceResponse<string>();
            int Wno = inboundListModel.warehouse_.id;
            int Pno = inboundListModel.parts_.id;
            int quantity = inboundListModel.count;

            StorageInfo storageInfo = await _storageInfoRepository.GetNavByIDAsync(Wno,Pno);
            try
            {
                if (storageInfo != null)
                {
                    storageInfo.count += quantity;
                    inboundListModel.inbound_state = Shared.Enums.InboundState.已入库;
                    if (await _storageInfoRepository.UpdateAsync(storageInfo) && await _inboundListRepository.UpdateAsync(_mapper.Map<InboundListModel, InboundList>(inboundListModel)))
                    {
                        //成功
                        response.Success = true;
                        response.Message = "入库成功";
                    }
                    else
                    {
                        //失败
                        response.Success = false;
                        response.Message = "入库失败";
                    }
                }
                else
                {
                    List<int> IDlist = new List<int>();
                    IDlist.Add(Wno);
                    IDlist.Add(Pno);
                    inboundListModel.inbound_state = Shared.Enums.InboundState.已入库;
                    if (await _storageInfoRepository.InsertNavAsync(IDlist, quantity)&& await _inboundListRepository.UpdateAsync(_mapper.Map<InboundListModel, InboundList>(inboundListModel)))
                    {
                        response.Success = true;
                        response.Message = "入库成功";
                    }
                    else
                    {
                        //失败
                        response.Success = false;
                        response.Message = "入库失败";
                    }
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
