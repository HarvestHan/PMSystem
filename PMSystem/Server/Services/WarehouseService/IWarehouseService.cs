namespace PMSystem.Server.Services.WarehouseService
{
    public interface IWarehouseService
    {
        //获取仓库列表
        Task<ServiceResponse<List<WarehouseModel>>> GetWarehouses();

        //添加仓库
        Task<ServiceResponse<string>> AddWarehouse(AddWarehouseModel warehouseModel);

        //删除仓库
        Task<ServiceResponse<string>> DeleteWarehouseByID(int id);

        //更新仓库
        Task<ServiceResponse<string>> UpdateWarehouse(UpdateWarehouseModel warehouseModel);
        
    }
}
