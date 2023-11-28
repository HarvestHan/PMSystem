using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PMSystem.Server.Services.PartsService;
using PMSystem.Shared;

namespace PMSystem.Server.Controllers
{
    /// <summary>
    /// 盘点单控制器
    /// </summary>
    [CustomHandleError]
    [Route("api/[controller]")]
    [ApiController]
    public class CheckListController : ControllerBase
    {
        private ICheckListService _checkListService { get; set; }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="checkListService"></param>
        public CheckListController(ICheckListService checkListService)
        {
            this._checkListService = checkListService;
        }

        #region GET

        /// <summary>
        /// 获取盘点单列表
        /// </summary>
        /// <returns></returns>

        [HttpGet("all")]
        public async Task<ActionResult<ServiceResponse<List<CheckListModel>>>> GetCheckLists()
        {
            var response = await _checkListService.GetCheckLists();
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        #endregion

        #region POST

        /// <summary>
        /// 添加盘点单
        /// </summary>
        /// <param name="checkListModel"></param>
        /// <returns></returns>
        [HttpPost("add")]
        //[Authorize(Roles = "Admin,InstitutePrincipal,InstituteVice,DivisionPrincipal")]
        public async Task<ActionResult<ServiceResponse<string>>> AddCheckList([FromBody] AddCheckListModel checkListModel)
        {
            var response = await _checkListService.AddCheckList(checkListModel);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        #endregion

        #region PUT

        /// <summary>
        /// 更新盘点单
        /// </summary>
        /// <param name="checkListModel"></param>
        /// <returns></returns>
        [HttpPut("update")]
        //[Authorize(Roles = "Admin,InstitutePrincipal,InstituteVice,DivisionPrincipal")]
        public async Task<ActionResult<ServiceResponse<string>>> UpdateCheckList(UpdateCheckListModel checkListModel)
        {
            var response = await _checkListService.UpdateCheckList(checkListModel);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        #endregion

        #region DELETE

        /// <summary>
        /// 删除盘点单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("delete")]
        //[Authorize(Roles = "Admin,InstitutePrincipal,InstituteVice,DivisionPrincipal")]
        public async Task<ActionResult<ServiceResponse<string>>> DeleteCheckList(int id)
        {
            var response = await _checkListService.DeleteCheckListByID(id);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        #endregion
    }
}
