using AutoMapper;
using PMSystem.Shared.Models;

namespace PMSystem.Client.Profiles
{
    public class WarehouseProfile:Profile
    {
        public WarehouseProfile()
        {
            CreateMap<WarehouseModel, AddWarehouseModel>();
            CreateMap<WarehouseModel, UpdateWarehouseModel>();
            CreateMap<WarehouseModel, SimpleWarehouseModel>();
            CreateMap<SimpleWarehouseModel, WarehouseModel>();
        }
    }
}
