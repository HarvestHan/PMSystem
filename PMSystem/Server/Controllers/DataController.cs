using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PMSystem.Shared;

namespace PMSystem.Server.Controllers
{
    /// <summary>
    /// 数据库控制器
    /// </summary>
    [CustomHandleError]
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private ISqlSugarClient _client;
        private IAuthService _authService;
        public DataController(ISqlSugarClient client, IAuthService authService)
        {
            _client = client;
            _authService = authService;
        }

        #region GET
        /// <summary>
        /// 生成数据库
        /// </summary>
        /// <returns></returns>
        [HttpGet("data")]
        public async Task<ActionResult<ServiceResponse<string>>> Generate()
        {
            try
            {
                _client.DbMaintenance.CreateDatabase();
                //基本信息表
                _client.CodeFirst.InitTables(typeof(Warehouse));
                _client.CodeFirst.InitTables(typeof(Parts));
                _client.CodeFirst.InitTables(typeof(InboundList));
                _client.CodeFirst.InitTables(typeof(OutboundList));
                _client.CodeFirst.InitTables(typeof(CheckList));
                _client.CodeFirst.InitTables(typeof(TransferList));
                _client.CodeFirst.InitTables(typeof(StorageInfo));

                //基本信息表
                _client.CodeFirst.InitTables(typeof(Role));
                _client.CodeFirst.InitTables(typeof(User));
                _client.CodeFirst.InitTables(typeof(UserRoleMapping));

                return Ok(new ServiceResponse<string>() { Success = true, Data = "建表成功" });
            }
            catch (Exception ex)
            {
                return BadRequest(new ServiceResponse<string>() { Message = ex.Message });
            }

        }

        [HttpGet("ChangePassword")]
        public async Task<ActionResult<string>> Change()
        {
            var list = await _client.Queryable<User>().ToListAsync();
            foreach(var item in list)
            {
                item.user_password = _authService.EncryptPassword(item.user_code);
            }
            if (await _client.Updateable(list).ExecuteCommandAsync() > 0)
            {
                return "成功";
            }
            return "失败";
        }
        #endregion
    }
}
