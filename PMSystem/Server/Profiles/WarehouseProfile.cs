namespace PMSystem.Server.Profiles
{
    /// <summary>
	/// 仓库Profile
	/// </summary>
    public class WarehouseProfile:Profile
    {
        /// <summary>
		/// 构造函数
		/// </summary>
		public WarehouseProfile()
        {
            CreateMap<Warehouse, WarehouseModel>();
            CreateMap<WarehouseModel, Warehouse>();
            CreateMap<Warehouse, SimpleWarehouseModel>();
            CreateMap<SimpleWarehouseModel, Warehouse>();
            CreateMap<UpdateWarehouseModel, Warehouse>();
            CreateMap<Warehouse, UpdateWarehouseModel>();
            CreateMap<AddWarehouseModel, Warehouse>();
        }
    }
}
