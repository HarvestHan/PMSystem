using DocumentFormat.OpenXml.Office2010.Excel;
using PMSystem.Server.DataBase;

namespace PMSystem.Server.Services.RoleService
{
    /// <summary>函数
    /// 权限Service
    /// </summary>
    public class RoleService : IRoleService
    {
        private readonly IMapper _mapper;
        private readonly RoleRepository _roleRepository;
        private readonly UserRepository _userRepository;
        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="roleRepository"></param>
        public RoleService(IMapper mapper, RoleRepository roleRepository, UserRepository userRepository)
        {
            _mapper = mapper;
            _roleRepository = roleRepository;
            _userRepository = userRepository;
        }
        /// <summary>
        /// 获取用户权限
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ServiceResponse<RoleModel>> GetRole(int id)
        {
            //var response = new ServiceResponse<RoleModel>();
            //try
            //{
            //    User user = await _userRepository.GetNavByIDAsync(id);
            //    RoleModel role = _mapper.Map<Role, RoleModel>(user.Role);
            //    response.Data = role;
            //    response.Success = true;
            //    response.Message = "获取成功";
            //} 
            //catch (Exception ex)
            //{
            //    response.Success = false;
            //    response.Message = ex.Message;
            //}
            //return response;
            throw new NotImplementedException();
        }
        /// <summary>
        /// 获取权限列表
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ServiceResponse<List<RoleModel>>> GetRoles()
        {
            var response = new ServiceResponse<List<RoleModel>>();
            try
            {
                var list = _mapper.Map<List<Role>, List<RoleModel>>(await _roleRepository.GetListAsync());
                response.Success = true;
                response.Data = list;
            }
            catch
            {
                response.Success = false;
            }
            return response;
        }

        public async Task<ServiceResponse<List<RoleModel>>> GetRolesByUserID(int userID)
        {
            var response = new ServiceResponse<List<RoleModel>>();
            try
            {
                var user = _mapper.Map<User, UserModel>(await _userRepository.GetByIdAsync(userID));
                response.Data = user.Roles;
                response.Success = true;
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
