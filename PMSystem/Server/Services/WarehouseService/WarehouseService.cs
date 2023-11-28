using PMSystem.Server.DataBase;
using PMSystem.Shared;
using PMSystem.Shared.Models;

namespace PMSystem.Server.Services.WarehouseService
{
    /// <summary>
    /// 仓库Service
    /// </summary>
    public class WarehouseService:IWarehouseService
    {
        private IMapper _mapper;
        private WarehouseRepository _warehouseRepository;
        private IUserService _userService;
        private UserRepository _userRepository;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="repository"></param>
        /// <param name="userService"></param>
        /// <param name="userRepository"></param>
        public WarehouseService(IMapper mapper, WarehouseRepository repository, IUserService userService, UserRepository userRepository)
        {
            this._mapper = mapper;
            this._warehouseRepository = repository;
            this._userService = userService;
            this._userRepository = userRepository;
        }

        /// <summary>
        /// 获取所有仓库信息
        /// </summary>
        /// <returns></returns>
        public async Task<ServiceResponse<List<WarehouseModel>>> GetWarehouses()
        {
            var response = new ServiceResponse<List<WarehouseModel>>();
            try
            {
                var list = _mapper.Map<List<Warehouse>, List<WarehouseModel>>(await _warehouseRepository.GetListNavAsync());
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
		/// 添加仓库
		/// </summary>
		/// <param name="warehouseModel"></param>
		/// <returns></returns>
		public async Task<ServiceResponse<string>> AddWarehouse(AddWarehouseModel warehouseModel)
        {
            var response = new ServiceResponse<string>();
            //转为Warehouse，再插入
            Warehouse warehouse = _mapper.Map<AddWarehouseModel, Warehouse>(warehouseModel);
            if (await _warehouseRepository.InsertAsync(warehouse))
            {
                //成功
                response.Success = true;
                response.Message = "添加仓库成功!";
            }
            else
            {
                //失败
                response.Success = false;
                response.Message = "添加仓库失败";
            }
            //返回结果
            return response;
        }

        /// <summary>
		/// 通过仓库ID删除仓库
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		/// <exception cref="NotImplementedException"></exception>
		public async Task<ServiceResponse<string>> DeleteWarehouseByID(int id)
        {
            var response = new ServiceResponse<string>();
            try
            {
                if (await _warehouseRepository.DeleteByIdAsync(id))
                {
                    response.Success = true;
                    response.Message = "仓库删除成功";
                }
                else
                {
                    response.Message = "仓库删除失败";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        /// <summary>
        /// 更新仓库信息
        /// </summary>
        /// <param name="warehouseModel"></param>
        /// <returns></returns>
        public async Task<ServiceResponse<string>> UpdateWarehouse(UpdateWarehouseModel warehouseModel)
        {
            var response = new ServiceResponse<string>();
            //转为Warehouse
            Warehouse warehouse = _mapper.Map<UpdateWarehouseModel, Warehouse>(warehouseModel);
            if (await _warehouseRepository.UpdateAsync(warehouse))
            {
                //成功
                response.Success = true;
                response.Message = "仓库信息更新成功";
            }
            else
            {
                //失败
                response.Success = false;
                response.Message = "仓库信息更新失败";
            }
            //返回结果
            return response;
        }
    }
}
