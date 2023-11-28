using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PMSystem.Server.Services.InboundListService;
using PMSystem.Shared;
namespace PMSystem.Server.Controllers
{
    /// <summary>
    /// 入库单控制器
    /// </summary>
    [CustomHandleError]
    [Route("api/[controller]")]
    [ApiController]
    public class InboundListController : ControllerBase
    {
        private IInboundListService _inboundListService { get; set; }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="inboundListService"></param>
        public InboundListController(IInboundListService inboundListService)
        {
            this._inboundListService = inboundListService;
        }

        #region GET

        /// <summary>
        /// 获取入库单列表
        /// </summary>
        /// <returns></returns>

        [HttpGet("all")]
        public async Task<ActionResult<ServiceResponse<List<InboundListModel>>>> GetInboundLists()
        {
            var response = await _inboundListService.GetInboundLists();
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        #endregion

        #region POST

        /// <summary>
        /// 添加入库单
        /// </summary>
        /// <param name="inboundListModel"></param>
        /// <returns></returns>
        [HttpPost("add")]
        //[Authorize(Roles = "Admin,InstitutePrincipal,InstituteVice,DivisionPrincipal")]
        public async Task<ActionResult<ServiceResponse<string>>> AddInboundList([FromBody] AddInboundListModel inboundListModel)
        {
            var response = await _inboundListService.AddInboundList(inboundListModel);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        /// <summary>
        /// 更新零件信息
        /// </summary>
        /// <param name="inboundListModel"></param>
        /// <returns></returns>
        [HttpPut("updatequantity")]
        public async Task<ActionResult<ServiceResponse<string>>> UpdateQuantity(InboundListModel inboundListModel)
        {
            var response = await _inboundListService.UpdateQuantity(inboundListModel);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        #endregion

        #region PUT

        /// <summary>
        /// 更新入库单
        /// </summary>
        /// <param name="inboundListModel"></param>
        /// <returns></returns>
        [HttpPut("update")]
        //[Authorize(Roles = "Admin,InstitutePrincipal,InstituteVice,DivisionPrincipal")]
        public async Task<ActionResult<ServiceResponse<string>>> UpdateInboundList(UpdateInboundListModel inboundListModel)
        {
            var response = await _inboundListService.UpdateInboundList(inboundListModel);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        #endregion

        #region DELETE

        /// <summary>
        /// 删除入库单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("delete")]
        //[Authorize(Roles = "Admin,InstitutePrincipal,InstituteVice,DivisionPrincipal")]
        public async Task<ActionResult<ServiceResponse<string>>> DeleteInboundList(int id)
        {
            var response = await _inboundListService.DeleteInboundListByID(id);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        #endregion
    }
}
