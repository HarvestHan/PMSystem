using PMSystem.Server.DataBase;
using PMSystem.Server.Entities;
using PMSystem.Server.Services.AuthService;
using PMSystem.Shared;

namespace PMSystem.Server.Services.UserService
{
    /// <summary>
    /// 用户Service
    /// </summary>
    public class UserService : IUserService
    {
        private IMapper _mapper;
        private UserRepository _userRepository;
        private UserRoleMappingRepository _userRoleMappingRepositor;
        private IAuthService _authService;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="repository"></param>
        public UserService(IMapper mapper,UserRepository repository,UserRoleMappingRepository userRoleMappingRepository, IAuthService _authService)
        {
            this._mapper = mapper;
            this._userRepository = repository;
            this._userRoleMappingRepositor = userRoleMappingRepository;
            this._authService = _authService;
        }

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="userModel"></param>
        /// <returns></returns>
        public async Task<ServiceResponse<string>> AddUser(AddUserModel userModel)
        {
            var response = new ServiceResponse<string>();
            //转为User再插入
            User user = _mapper.Map<AddUserModel, User>(userModel);
            if(await _userRepository.InsertNavAsync(user))
            {
                //成功
                response.Success = true;
                response.Message = "添加成功";
            }
            else
            {
                response.Success = false;
                response.Message = "添加失败";
            }
            //返回结果
            return response;
        }
        /// <summary>
        /// 通过ID删除用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ServiceResponse<string>> DeleteUserByID(int id)
        {
            var response = new ServiceResponse<string>();
            try
            {
                if (await _userRepository.DeleteByIdAsync(id))
                {
                    response.Success = true;
                    response.Message = "删除成功";
                }
                else
                {
                    response.Success = false;
                    response.Message = "删除失败";
                }
            }
            catch
            {
                response.Success = false;
                response.Message = "执行出错";
            }
            return response;
        }

        /// <summary>
        /// 导航查询用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ServiceResponse<UserModel>> GetUserNavByIDAsync(int id)
        {
            var response = new ServiceResponse<UserModel>();
            try
            {
                //查询所有一级指标
                var user = _mapper.Map<User, UserModel>(await _userRepository.GetNavByIDAsync(id));

                response.Data = user;
                response.Success = true;
            }
            catch
            {
                response.Success = false;
                response.Message = "查询失败";
            }
            return response;
        }
        /// <summary>
        /// 通过ID查询用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ServiceResponse<UserModel>> GetUserByID(int id)
        {
            var response = new ServiceResponse<UserModel>();
            try
            {
                //查询所有一级指标
                var user = _mapper.Map<User, UserModel>(await _userRepository.GetByIdAsync(id));

                response.Data = user;
                response.Success = true;
            }
            catch
            {
                response.Success = false;
                response.Message = "查询失败";
            }
            return response;
        }
        /// <summary>
        /// 获取所有用户
        /// </summary>
        /// <returns></returns>
        public async Task<ServiceResponse<List<UserModel>>> GetUsers()
        {
            var response = new ServiceResponse<List<UserModel>>();
            try
            {

                var list = _mapper.Map<List<User>, List<UserModel>>(await _userRepository.GetListNavAsync());

                response.Data = list;
                response.Success = true;
            }
            catch
            {
                response.Success = false;
                response.Message = "查询失败";
            }
            return response;
        }

        /// <summary>
        /// 通过权限获取所有用户
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public async Task<ServiceResponse<List<UserModel>>> GetUsersByRole(RoleModel role)
        {
            return await GetUsersByRoleID(role.id);
        }
        /// <summary>
        /// 通过RoleID获取所有用户
        /// </summary>
        /// <param name="roleID"></param>
        /// <returns></returns>
        public async Task<ServiceResponse<List<UserModel>>> GetUsersByRoleID(int roleID)
        {
            var response = new ServiceResponse<List<UserModel>>();
            try
            {
                var list = _mapper.Map<List<User>, List<UserModel>>(await _userRepository.GetListByRoleIDAsync(roleID));

                response.Data = list;
                response.Success = true;
            }
            catch
            {
                response.Success = false;
                response.Message = "查询失败";
            }
            return response;
        }
        /// <summary>
        /// 更新用户信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<ServiceResponse<string>> UpdateUser(UpdateUserModel user)
        {
            var response = new ServiceResponse<string>();
            try
            {
                if (await _userRepository.UpdateAsync(_mapper.Map<UpdateUserModel, User>(user)))
                {
                    response.Success = true;
                    response.Message = "更新成功";
                }
                else
                {
                    response.Success = false;
                    response.Message = "更新失败";
                }
            }
            catch
            {
                response.Success = false;
                response.Message = "执行出错";
            }
            return response;
        }

        /// <summary>
        /// 修改用户密码
        /// </summary>
        /// <param name="model">传入ChangeUsersPwdModel</param>
        /// <returns></returns>
        public async Task<ServiceResponse<string>> ChangeUsersPwd(ChangeUsersPwdModel model, string newPassword)
        {
            var response = new ServiceResponse<string>();

            //数据库查询
            var result = await _userRepository.GetListByCodeAsync(model.Code);
            foreach(var item in result)
            {
                item.user_password = _authService.EncryptPassword(newPassword);
            }
            if (await _userRepository.UpdateRangeAsync(result))
            {
                response.Success = true;
                response.Message = "修改成功";
            }
            else
            {
                response.Message = "修改失败";
            }
            return response;
        }

        public async Task<ServiceResponse<string>> ChangePwd(List<int> userID)
        {
            var response = new ServiceResponse<string>();
            try
            {
                var results = await _userRepository.GetByIDListAsync(userID);
                foreach (var item in results)
                {
                    item.user_password = _authService.EncryptPassword(item.user_password);
                }
                if (await _userRepository.UpdateRangeAsync(results.ToArray()))
                {
                    response.Success = true;
                    response.Message = "更新成功!";
                }
                else
                {
                    response.Message = "更新失败!";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<User> ServerGetUser(int id)
        {
            return await _userRepository.GetAllUserInfo(id);
        }

		public async Task<ServiceResponse<string>> AddRole(int userID, int roleID)
		{
            var response = new ServiceResponse<string>();
            try
            {
                if (await _userRoleMappingRepositor.InsertNavAsync(userID,roleID))
                {
                    response.Success = true;
                    response.Message = "添加成功";
                }
                else
                {
                    response.Message = "添加失败";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
		}

		public async Task<ServiceResponse<string>> DeleteRole(int userID, int roleID)
		{
			var response = new ServiceResponse<string>();
            try
            {
                if (await _userRoleMappingRepositor.DeleteRole(userID, roleID))
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

        public async Task<List<User>> ServerGetUsers()
        {
            return await _userRepository.GetListNavAsync();
        }

    }
}
