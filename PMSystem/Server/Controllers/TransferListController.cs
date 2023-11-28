using Microsoft.AspNetCore.Mvc;

namespace PMSystem.Server.Controllers
{
    /// <summary>
    /// 调拨单控制器
    /// </summary>
    [CustomHandleError]
    [Route("api/[controller]")]
    [ApiController]
    public class TransferListController : ControllerBase
    {
        private ITransferListService _transferListService { get; set; }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="transferListService"></param>
        public TransferListController(ITransferListService transferListService)
        {
            this._transferListService = transferListService;
        }

        #region GET

        /// <summary>
        /// 获取调拨单列表
        /// </summary>
        /// <returns></returns>

        [HttpGet("all")]
        public async Task<ActionResult<ServiceResponse<List<TransferListModel>>>> GetTransferLists()
        {
            var response = await _transferListService.GetTransferLists();
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        #endregion

        #region POST

        /// <summary>
        /// 添加调拨单
        /// </summary>
        /// <param name="transferListModel"></param>
        /// <returns></returns>
        [HttpPost("add")]
        //[Authorize(Roles = "Admin,InstitutePrincipal,InstituteVice,DivisionPrincipal")]
        public async Task<ActionResult<ServiceResponse<string>>> AddInboundList([FromBody] AddTransferListModel transferListModel)
        {
            var response = await _transferListService.AddTransferList(transferListModel);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        /// <summary>
        /// 更新调拨
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        [HttpPost("transfer")]
        //[Authorize(Roles = "Admin,InstitutePrincipal,InstituteVice,DivisionPrincipal")]
        public async Task<ActionResult<ServiceResponse<string>>> Transfer(List<int> list)
        {
            var response = await _transferListService.Transfer(list);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        #endregion

        #region PUT

        /// <summary>
        /// 更新调拨单
        /// </summary>
        /// <param name="transferListModel"></param>
        /// <returns></returns>
        [HttpPut("update")]
        //[Authorize(Roles = "Admin,InstitutePrincipal,InstituteVice,DivisionPrincipal")]
        public async Task<ActionResult<ServiceResponse<string>>> UpdateTransferList(UpdateTransferListModel transferListModel)
        {
            var response = await _transferListService.UpdateTransferList(transferListModel);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        #endregion

        #region DELETE

        /// <summary>
        /// 删除调拨单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("delete")]
        //[Authorize(Roles = "Admin,InstitutePrincipal,InstituteVice,DivisionPrincipal")]
        public async Task<ActionResult<ServiceResponse<string>>> DeleteTransferList(int id)
        {
            var response = await _transferListService.DeleteTransferListByID(id);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        #endregion
    }
}
