namespace PMSystem.Server.Profiles
{
    /// <summary>
	/// 零件Profile
	/// </summary>
    public class PartsProfile : Profile
    {
        /// <summary>
		/// 构造函数
		/// </summary>
		public PartsProfile()
        {
            CreateMap<Parts, PartsModel>();
            CreateMap<PartsModel, Parts>();
            CreateMap<Parts, SimplePartsModel>();
            CreateMap<SimplePartsModel, Parts>();
            CreateMap<UpdatePartsModel, Parts>();
            CreateMap<AddPartsModel, Parts>();
            CreateMap<Parts, UpdatePartsModel>();
        }
    }
}
