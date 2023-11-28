using PMSystem.Shared;

namespace PMSystem.Client.Services.WarehouseService
{
    public interface IWarehouseService
    {
        Task<ServiceResponse<List<WarehouseModel>>> GetWarehouses();

        Task<ServiceResponse<string>> AddWarehouse(AddWarehouseModel warehouse);

        Task<ServiceResponse<string>> DeleteWarehouse(int id);

        Task<ServiceResponse<string>> UpdateWarehouse(UpdateWarehouseModel warehouse);
    }
}
