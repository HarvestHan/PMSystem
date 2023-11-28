namespace PMSystem.Server.Profiles
{
    /// <summary>
	/// 出库单Profile
	/// </summary>
    public class OutboundListProfile : Profile
    {
        /// <summary>
		/// 构造函数
		/// </summary>
		public OutboundListProfile()
        {
            CreateMap<OutboundList, OutboundListModel>();
            CreateMap<OutboundListModel, OutboundList>();
            CreateMap<UpdateOutboundListModel, OutboundList>();
            CreateMap<AddOutboundListModel, OutboundList>();
        }
    }
}
