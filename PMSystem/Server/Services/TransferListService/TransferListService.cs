using PMSystem.Server.DataBase;
using PMSystem.Server.Entities;
using PMSystem.Shared;
using PMSystem.Shared.Models;

namespace PMSystem.Server.Services.TransferListService
{
    /// <summary>
    /// 调拨单Service
    /// </summary>
    public class TransferListService:ITransferListService
    {
        private IMapper _mapper;
        private TransferListRepository _transferListRepository;
        private StorageInfoRepository _storageInfoRepository;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="repository"></param>
        /// <param name="storageInfoRepository"></param>
        public TransferListService(IMapper mapper, TransferListRepository repository, StorageInfoRepository storageInfoRepository)
        {
            this._mapper = mapper;
            this._transferListRepository = repository;
            this._storageInfoRepository = storageInfoRepository;
        }

        /// <summary>
        /// 获取所有调拨单信息
        /// </summary>
        /// <returns></returns>
        public async Task<ServiceResponse<List<TransferListModel>>> GetTransferLists()
        {
            var response = new ServiceResponse<List<TransferListModel>>();
            try
            {
                var list = _mapper.Map<List<TransferList>, List<TransferListModel>>(await _transferListRepository.GetListNavAsync());
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
		/// 添加调拨单
		/// </summary>
		/// <param name="transferListModel"></param>
		/// <returns></returns>
        public async Task<ServiceResponse<string>> AddTransferList(AddTransferListModel transferListModel)
        {
            var response = new ServiceResponse<string>();
            //转为InboundList，再插入
            TransferList transferList = _mapper.Map<AddTransferListModel, TransferList>(transferListModel);
            if (await _transferListRepository.InsertNavAsync(transferList))
            {
                //成功
                response.Success = true;
                response.Message = "添加调拨单成功!";
            }
            else
            {
                //失败
                response.Success = false;
                response.Message = "添加调拨单失败";
            }
            //返回结果
            return response;
        }

        /// <summary>
		/// 通过ID删除调拨单
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		/// <exception cref="NotImplementedException"></exception>
		public async Task<ServiceResponse<string>> DeleteTransferListByID(int id)
        {
            var response = new ServiceResponse<string>();
            try
            {
                if (await _transferListRepository.DeleteByIdAsync(id))
                {
                    response.Success = true;
                    response.Message = "删除调拨单成功";
                }
                else
                {
                    response.Message = "删除调拨单失败";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        /// <summary>
        /// 更新调拨单信息
        /// </summary>
        /// <param name="transferListModel"></param>
        /// <returns></returns>
        public async Task<ServiceResponse<string>> UpdateTransferList(UpdateTransferListModel transferListModel)
        {
            var response = new ServiceResponse<string>();
            //转为TransferList
            TransferList transferList = _mapper.Map<UpdateTransferListModel, TransferList>(transferListModel);
            if (await _transferListRepository.UpdateAsync(transferList))
            {
                //成功
                response.Success = true;
                response.Message = "更新调拨单成功";
            }
            else
            {
                //失败
                response.Success = false;
                response.Message = "更新调拨单失败";
            }
            //返回结果
            return response;
        }

        /// <summary>
        /// 更新零件调拨数量信息
        /// </summary>
        /// <returns></returns>
        public async Task<ServiceResponse<string>> Transfer(List<int> list)
        {
            var response = new ServiceResponse<string>();
            StorageInfo storageOutInfo = await _storageInfoRepository.GetNavByIDAsync(list[1], list[0]);
            StorageInfo storageInInfo = await _storageInfoRepository.GetNavByIDAsync(list[2], list[0]);
            try
            {
                storageOutInfo.count -= list[3];
                storageInInfo.count += list[3];
                if (await _storageInfoRepository.UpdateAsync(storageOutInfo) && await _storageInfoRepository.UpdateAsync(storageInInfo))
                {
                    //成功
                    response.Success = true;
                    response.Message = "调拨成功";
                }
                else
                {
                    //失败
                    response.Success = false;
                    response.Message = "调拨失败";
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
