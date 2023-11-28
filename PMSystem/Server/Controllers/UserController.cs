
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PMSystem.Server.Entities;
using PMSystem.Server.Services.AuthService;
using PMSystem.Server.Services.UserService;
using PMSystem.Shared;

namespace PMSystem.Server.Controllers
{
    /// <summary>
    /// 用户控制器
    /// </summary>
    [CustomHandleError]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService { get; set; }
        private IAuthService _authService { get; set; }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userService"></param>
        /// <param name="authService"></param>
        public UserController(IUserService userService,IAuthService authService)
        {
            this._userService = userService;
            this._authService = authService;
        }

        #region GET
        /// <summary>
        /// 获取所有用户
        /// </summary>
        /// <returns></returns>
        [HttpGet("all")]
        public async Task<ActionResult<ServiceResponse<List<UserModel>>>> GetUsers()
        {
            var response = await _userService.GetUsers();
            if (response.Success)
            {
                return Ok(response);
            }
            else
            {
                response.Message = "请求失败";
                return BadRequest(response);
            }
        }
        /// <summary>
        /// 通过ID获取用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("getuserbyid")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<UserModel>>> GetUserByID(int id)
        {
            var response = await _userService.GetUserByID(id);
            if (response.Success)
            {
                return Ok(response);
            }
            else
            {
                response.Message = "请求失败";
                return BadRequest(response);
            }
        }
        /// <summary>
        /// 通过roleID获取用户
        /// </summary>
        /// <param name="roleID"></param>
        /// <returns></returns>
        [HttpGet("getuserbyroleid")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<UserModel>>> GetUserByRoleID(int roleID)
        {
            var response = await _userService.GetUsersByRoleID(roleID);
            if (response.Success)
            {
                return Ok(response);
            }
            else
            {
                response.Message = "请求失败";
                return BadRequest(response);
            }
        }
        /// <summary>
        /// 获取用户
        /// </summary>
        /// <returns></returns>
        /// 这里是用户登录后需要调用的，每个用户都可以
        [HttpGet("getuser")]
        [Authorize(Roles = "Admin,Supervisor,InboundClerk,Keeper,OutboundClerk,User")]

        public async Task<ActionResult<ServiceResponse<UserModel>>> GetUser()
        {
            var response = await _userService.GetUserNavByIDAsync(_authService.GetUserID());
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
        #endregion

        #region POST
        /// <summary>
        /// 添加新用户
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("add")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<string>>> AddUser(AddUserModel model)
        {
            model.user_password = _authService.EncryptPassword(model.user_password);
            var response = await _userService.AddUser(model);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        /// <summary>
        /// 修改密码POST
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("changeuserspwd")]
        public async Task<ActionResult<ServiceResponse<string>>> ChangeUsersPwd(ChangeUsersPwdModel model, string newPassword)
        {
            var response = await _userService.ChangeUsersPwd(model,newPassword);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        #endregion

        #region PUT
        /// <summary>
        /// 更新用户信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPut("update")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<string>>> UpdateUser(UpdateUserModel user)
        {
            var response = await _userService.UpdateUser(user);
            if (response.Success) 
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
        [HttpPost("changepwd")]
        public async Task<ActionResult<ServiceResponse<string>>> ChangePwd(List<int> userID)
        {
            var response = await _userService.ChangePwd(userID);
            return response.Success ? Ok(response) : BadRequest(Response);
        }
        /// <summary>
        /// 添加权限
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="roleID"></param>
        /// <returns></returns>
        [HttpPut("addrole")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<string>>> AddRole(int userID, int roleID)
        {
            var response = await _userService.AddRole(userID,roleID);
            return response.Success ? Ok(response) : BadRequest(response);
        }
        /// <summary>
        /// 删除权限
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="roleID"></param>
        /// <returns></returns>
        [HttpPut("deleterole")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<string>>> DeleteRole(int userID, int roleID)
        {
            var response = await _userService.DeleteRole(userID,roleID);
            return response.Success ? Ok(response):BadRequest(response); 
        }
        #endregion

        #region DELETE
        /// <summary>
        /// 通过ID删除用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("delete")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<string>>> Delete(int id)
        {
            var response = await _userService.DeleteUserByID(id);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        #endregion
    }
}
