namespace PMSystem.Server.Profiles
{
    /// <summary>
	/// 调拨单Profile
	/// </summary>
    public class TransferListProfile:Profile
    {
        /// <summary>
		/// 构造函数
		/// </summary>
		public TransferListProfile()
        {
            CreateMap<TransferList, TransferListModel>();
            CreateMap<TransferListModel, TransferList>();
            CreateMap<UpdateTransferListModel, TransferList>();
            CreateMap<AddTransferListModel, TransferList>();
        }
    }
}
