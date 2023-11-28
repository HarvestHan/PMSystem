using PMSystem.Server.DataBase;
using PMSystem.Server.Entities;
using PMSystem.Shared;

namespace PMSystem.Server.Services.PartsService
{
    /// <summary>
    /// 零件Service
    /// </summary>
    public class PartsService:IPartsService
    {
        private IMapper _mapper;
        private PartsRepository _partsRepository;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="repository"></param>
        public PartsService(IMapper mapper, PartsRepository repository)
        {
            _mapper = mapper;
            _partsRepository = repository;
        }

        /// <summary>
        /// 获取所有零件信息
        /// </summary>
        /// <returns></returns>
        public async Task<ServiceResponse<List<PartsModel>>> GetParts()
        {
            var response = new ServiceResponse<List<PartsModel>>();
            try
            {
                var list = _mapper.Map<List<Parts>, List<PartsModel>>(await _partsRepository.GetListNavAsync());
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
		/// 添加零件
		/// </summary>
		/// <param name="partsModel"></param>
		/// <returns></returns>
		public async Task<ServiceResponse<string>> AddParts(AddPartsModel partsModel)
        {
            var response = new ServiceResponse<string>();
            //转为Parts，再插入
            Parts parts = _mapper.Map<AddPartsModel, Parts>(partsModel);
            if (await _partsRepository.InsertAsync(parts))
            {
                //成功
                response.Success = true;
                response.Message = "添加成功!";
            }
            else
            {
                //失败
                response.Success = false;
                response.Message = "添加失败";
            }
            //返回结果
            return response;
        }

        /// <summary>
		/// 通过零件ID删除零件
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		/// <exception cref="NotImplementedException"></exception>
		public async Task<ServiceResponse<string>> DeletePartsByID(int id)
        {
            var response = new ServiceResponse<string>();
            try
            {
                if (await _partsRepository.DeleteByIdAsync(id))
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
        /// 更新零件信息
        /// </summary>
        /// <param name="partsModel"></param>
        /// <returns></returns>
        public async Task<ServiceResponse<string>> UpdateParts(UpdatePartsModel partsModel)
        {
            var response = new ServiceResponse<string>();
            //转为Parts
            Parts parts = _mapper.Map<UpdatePartsModel, Parts>(partsModel);
            if (await _partsRepository.UpdateAsync(parts))
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
