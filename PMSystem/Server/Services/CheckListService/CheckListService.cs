using PMSystem.Server.DataBase;
using PMSystem.Shared;
using PMSystem.Shared.Models;

namespace PMSystem.Server.Services.CheckListService
{
    /// <summary>
    /// 盘点单Service
    /// </summary>
    public class CheckListService:ICheckListService
    {
        private IMapper _mapper;
        private CheckListRepository _checkListRepository;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="repository"></param>
        public CheckListService(IMapper mapper, CheckListRepository repository)
        {
            this._mapper = mapper;
            this._checkListRepository = repository;
        }

        /// <summary>
        /// 获取所有盘点单信息
        /// </summary>
        /// <returns></returns>
        public async Task<ServiceResponse<List<CheckListModel>>> GetCheckLists()
        {
            var response = new ServiceResponse<List<CheckListModel>>();
            try
            {
                var list = _mapper.Map<List<CheckList>, List<CheckListModel>>(await _checkListRepository.GetListNavAsync());
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
		/// 添加盘点单
		/// </summary>
		/// <param name="checkListModel"></param>
		/// <returns></returns>
		public async Task<ServiceResponse<string>> AddCheckList(AddCheckListModel checkListModel)
        {
            var response = new ServiceResponse<string>();
            //转为CheckList，再插入
            CheckList checkList = _mapper.Map<AddCheckListModel, CheckList>(checkListModel);
            if (await _checkListRepository.InsertNavAsync(checkList))
            {
                //成功
                response.Success = true;
                response.Message = "添加盘点单成功!";
            }
            else
            {
                //失败
                response.Success = false;
                response.Message = "添加盘点单失败";
            }
            //返回结果
            return response;
        }

        /// <summary>
		/// 通过盘点单ID删除盘点单
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		/// <exception cref="NotImplementedException"></exception>
		public async Task<ServiceResponse<string>> DeleteCheckListByID(int id)
        {
            var response = new ServiceResponse<string>();
            try
            {
                if (await _checkListRepository.DeleteByIdAsync(id))
                {
                    response.Success = true;
                    response.Message = "删除成功";
                }
                else
                {
                    response.Message = "删除失败";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        /// <summary>
        /// 更新盘点单信息
        /// </summary>
        /// <param name="checkListModel"></param>
        /// <returns></returns>
        public async Task<ServiceResponse<string>> UpdateCheckList(UpdateCheckListModel checkListModel)
        {
            var response = new ServiceResponse<string>();
            //转为CheckList
            CheckList checkList = _mapper.Map<UpdateCheckListModel, CheckList>(checkListModel);
            if (await _checkListRepository.UpdateAsync(checkList))
            {
                //成功
                response.Success = true;
                response.Message = "更新成功";
            }
            else
            {
                //失败
                response.Success = false;
                response.Message = "更新失败";
            }
            //返回结果
            return response;
        }
    }
}
