using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PMSystem.Server.Services.WarehouseService;
using PMSystem.Shared;

namespace PMSystem.Server.Controllers
{
    /// <summary>
    /// 仓库控制器
    /// </summary>
    [CustomHandleError]
    [Route("api/[controller]")]
    [ApiController]
    public class WarehouseController:ControllerBase
    {
        private IWarehouseService _warehouseService { get; set; }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="warehouseService"></param>
        public WarehouseController(IWarehouseService warehouseService)
        {
            this._warehouseService = warehouseService;
        }

        #region GET

        /// <summary>
        /// 获取仓库列表
        /// </summary>
        /// <returns></returns>

        [HttpGet("all")]
        public async Task<ActionResult<ServiceResponse<List<WarehouseModel>>>> GetWarehouses()
        {
            var response = await _warehouseService.GetWarehouses();
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
        /// <param name="warehouseModel"></param>
        /// <returns></returns>
        [HttpPost("add")]
        //[Authorize(Roles = "Admin,InstitutePrincipal,InstituteVice,DivisionPrincipal")]
        public async Task<ActionResult<ServiceResponse<string>>> AddWarehouse([FromBody] AddWarehouseModel warehouseModel)
        {
            var response = await _warehouseService.AddWarehouse(warehouseModel);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        #endregion

        #region PUT

        /// <summary>
        /// 更新仓库
        /// </summary>
        /// <param name="warehouseModel"></param>
        /// <returns></returns>
        [HttpPut("update")]
        //[Authorize(Roles = "Admin,InstitutePrincipal,InstituteVice,DivisionPrincipal")]
        public async Task<ActionResult<ServiceResponse<string>>> UpdateWarehouse(UpdateWarehouseModel warehouseModel)
        {
            var response = await _warehouseService.UpdateWarehouse(warehouseModel);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        #endregion

        #region DELETE

        /// <summary>
        /// 删除仓库
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("delete")]
        //[Authorize(Roles = "Admin,InstitutePrincipal,InstituteVice,DivisionPrincipal")]
        public async Task<ActionResult<ServiceResponse<string>>> DeleteWarehouse(int id)
        {
            var response = await _warehouseService.DeleteWarehouseByID(id);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        #endregion
    }
}
