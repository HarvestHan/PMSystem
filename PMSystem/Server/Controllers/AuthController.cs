using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PMSystem.Server.Services.AuthService;
using PMSystem.Shared;
using PMSystem.Shared.Models;
using SqlSugar;

namespace PMSystem.Server.Controllers
{
    /// <summary>
    /// 身份验证控制器
    /// </summary>
    [CustomHandleError]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthService _authService;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="authService"></param>
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        #region GET
        [HttpGet("loginInfo")]
        public async Task<ActionResult<ServiceResponse<LoginInfoModel>>> GetLoginInfo()
        {
            var response = await _authService.GetLoginInfo();
            return response.Success ? Ok(response) : BadRequest(response);
        }
        #endregion
        #region POST
        /// <summary>
        /// 登陆POST
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("login")]
        public async Task<ActionResult<ServiceResponse<string>>> Login(LoginModel request)
        {
            
            var response = await _authService.Login(request.UserName,request.PassWord);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        /// <summary>
        /// 修改密码POST
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("changepassword")]
        public async Task<ActionResult<ServiceResponse<string>>> ChangePassword(ChangePasswordModel request)
        {
            var response = await _authService.ChangePassword(request);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        #endregion
    }
}
