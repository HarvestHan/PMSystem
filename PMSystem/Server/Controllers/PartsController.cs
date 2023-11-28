using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PMSystem.Server.Services.PartsService;
using PMSystem.Shared;

namespace PMSystem.Server.Controllers
{
    /// <summary>
    /// 零件控制器
    /// </summary>
    [CustomHandleError]
    [Route("api/[controller]")]
    [ApiController]
    public class PartsController : ControllerBase
    {
        private IPartsService _partsService { get; set; }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="partsService"></param>
        public PartsController(IPartsService partsService)
        {
            this._partsService = partsService;
        }

        #region GET

        /// <summary>
        /// 获取零件列表
        /// </summary>
        /// <returns></returns>

        [HttpGet("all")]
        public async Task<ActionResult<ServiceResponse<List<PartsModel>>>> GetParts()
        {
            var response = await _partsService.GetParts();
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        #endregion

        #region POST

        /// <summary>
        /// 添加仓库
        /// </summary>
        /// <param name="partsModel"></param>
        /// <returns></returns>
        [HttpPost("add")]
        //[Authorize(Roles = "Admin,InstitutePrincipal,InstituteVice,DivisionPrincipal")]
        public async Task<ActionResult<ServiceResponse<string>>> AddParts([FromBody] AddPartsModel partsModel)
        {
            var response = await _partsService.AddParts(partsModel);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        #endregion

        #region PUT

        /// <summary>
        /// 更新零件
        /// </summary>
        /// <param name="partsModel"></param>
        /// <returns></returns>
        [HttpPut("update")]
        //[Authorize(Roles = "Admin,InstitutePrincipal,InstituteVice,DivisionPrincipal")]
        public async Task<ActionResult<ServiceResponse<string>>> UpdateParts(UpdatePartsModel partsModel)
        {
            var response = await _partsService.UpdateParts(partsModel);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        #endregion

        #region DELETE

        /// <summary>
        /// 删除零件
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("delete")]
        //[Authorize(Roles = "Admin,InstitutePrincipal,InstituteVice,DivisionPrincipal")]
        public async Task<ActionResult<ServiceResponse<string>>> DeleteParts(int id)
        {
            var response = await _partsService.DeletePartsByID(id);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        #endregion
    }
}
