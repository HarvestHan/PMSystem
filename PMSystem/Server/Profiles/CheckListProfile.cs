namespace PMSystem.Server.Profiles
{
    /// <summary>
	/// 盘点单Profile
	/// </summary>
    public class ChecklistProfile : Profile
    {
        /// <summary>
		/// 构造函数
		/// </summary>
		public ChecklistProfile()
        {
            CreateMap<CheckList, CheckListModel>();
            CreateMap<CheckListModel, CheckList>();
            CreateMap<UpdateCheckListModel, CheckList>();
            CreateMap<AddCheckListModel, CheckList>();
        }
    }
}
