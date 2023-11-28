using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PMSystem.Server.Services.AuthService;
using PMSystem.Server.Services.RoleService;

namespace PMSystem.Server.Controllers
{
    [CustomHandleError]
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private IRoleService _roleService;
        private IAuthService _authService;
        public RoleController(IRoleService roleService,IAuthService authService)
        {
            _roleService = roleService;
            _authService = authService;
        }
        #region GET
        [HttpGet("all")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<List<RoleModel>>>> GetRoles()
        {
            var respnse = await _roleService.GetRoles();
            if (respnse.Success)
            {
                return Ok(respnse);
            }
            return BadRequest(respnse);
        }
        [HttpGet("userrole")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<RoleModel>>> GetUserRole()
        {
            var response = await _roleService.GetRole(_authService.GetUserID());
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
        [HttpGet("rolesbyuserid")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<RoleModel>>> GetRolesByUserID(int userID)
        {
            var response = await _roleService.GetRolesByUserID(userID);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
        #endregion
    }
}
