using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PMSystem.Server.Controllers
{
    [CustomHandleError]
    [Route("api/[controller]")]
    [ApiController]
    public class StorageInfoController:ControllerBase
    {
        private IStorageInfoService _storageInfoService;
        public StorageInfoController(IStorageInfoService storageInfoService)
        {
            _storageInfoService = storageInfoService;
        }
        [HttpGet("all")]
        public async Task<ActionResult<ServiceResponse<List<StorageInfoModel>>>> GetStorageInfos()
        {
            return await _storageInfoService.GetStorageInfos();
        }
        [HttpGet("one")]
        public async Task<ActionResult<ServiceResponse<StorageInfoModel>>> GetStorageInfo(int Wno,int Pno)
        {
            return await _storageInfoService.GetStorageInfo(Wno,Pno);
        }
    }
}
