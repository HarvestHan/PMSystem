using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PMSystem.Server.Services.OutboundListService;
using PMSystem.Shared;


namespace PMSystem.Server.Controllers
{
    /// <summary>
    /// 出库单控制器
    /// </summary>
    [CustomHandleError]
    [Route("api/[controller]")]
    [ApiController]
    public class OutboundListController : ControllerBase
    {
        private IOutboundListService _outboundListService { get; set; }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="outboundListService"></param>
        public OutboundListController(IOutboundListService outboundListService)
        {
            this._outboundListService = outboundListService;
        }

        #region GET

        /// <summary>
        /// 获取出库单列表
        /// </summary>
        /// <returns></returns>

        [HttpGet("all")]
        public async Task<ActionResult<ServiceResponse<List<OutboundListModel>>>> GetOutboundLists()
        {
            var response = await _outboundListService.GetOutboundLists();
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        #endregion

        #region POST

        /// <summary>
        /// 添加出库单
        /// </summary>
        /// <param name="outboundListModel"></param>
        /// <returns></returns>
        [HttpPost("add")]
        //[Authorize(Roles = "Admin,InstitutePrincipal,InstituteVice,DivisionPrincipal")]
        public async Task<ActionResult<ServiceResponse<string>>> AddOutboundList([FromBody] AddOutboundListModel outboundListModel)
        {
            var response = await _outboundListService.AddOutboundList(outboundListModel);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        /// <summary>
        /// 更新零件信息
        /// </summary>
        /// <param name="outboundListModel"></param>
        /// <returns></returns>
        [HttpPut("updatequantity")]
        public async Task<ActionResult<ServiceResponse<string>>> UpdateQuantity(OutboundListModel outboundListModel)
        {
            var response = await _outboundListService.UpdateQuantity(outboundListModel);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        #endregion

        #region PUT

        /// <summary>
        /// 更新出库单
        /// </summary>
        /// <param name="outboundListModel"></param>
        /// <returns></returns>
        [HttpPut("update")]
        //[Authorize(Roles = "Admin,InstitutePrincipal,InstituteVice,DivisionPrincipal")]
        public async Task<ActionResult<ServiceResponse<string>>> UpdateOutboundList(UpdateOutboundListModel outboundListModel)
        {
            var response = await _outboundListService.UpdateOutboundList(outboundListModel);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        #endregion

        #region DELETE

        /// <summary>
        /// 删除出库单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("delete")]
        //[Authorize(Roles = "Admin,InstitutePrincipal,InstituteVice,DivisionPrincipal")]
        public async Task<ActionResult<ServiceResponse<string>>> DeleteOutboundList(int id)
        {
            var response = await _outboundListService.DeleteOutboundListByID(id);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        #endregion
    }
}
