namespace PMSystem.Server.Entities
{
    /// <summary>
    /// 零件存储信息表
    /// </summary>
    public class StorageInfo
    {
        /// <summary>
        /// 仓库ID
        /// </summary>
        [SugarColumn(IsPrimaryKey = true)]
        public int warehouse_id { get; set; }
        /// <summary>
        /// 仓库
        /// </summary>
        [Navigate(NavigateType.OneToOne,nameof(warehouse_id))]
        public Warehouse? warehouse_ { get; set; }
        /// <summary>
        /// 零件ID
        /// </summary>
        [SugarColumn(IsPrimaryKey = true)]
        public int parts_id { get; set; }
        /// <summary>
        /// 零件
        /// </summary>
        [Navigate(NavigateType.OneToOne, nameof(parts_id))]
        public Parts? parts_ { get; set; }
        /// <summary>
        /// 存储数量
        /// </summary>
        public int count { get; set; }
    }
}
