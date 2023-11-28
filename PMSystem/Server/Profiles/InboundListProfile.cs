namespace PMSystem.Server.Profiles
{
    /// <summary>
	/// 入库单Profile
	/// </summary>
    public class InboundListProfile : Profile
    {
        /// <summary>
		/// 构造函数
		/// </summary>
		public InboundListProfile()
        {
            CreateMap<InboundList, InboundListModel>();
            CreateMap<InboundListModel, InboundList>();
            CreateMap<UpdateInboundListModel, InboundList>();
            CreateMap<AddInboundListModel, InboundList>();
        }
    }
}
