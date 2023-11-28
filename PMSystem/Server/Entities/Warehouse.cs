namespace PMSystem.Server.Entities
{
    /// <summary>
    /// 仓库实体
    /// </summary>
    public class Warehouse:BaseEntity
    {
        /// <summary>
        /// 仓库编码
        /// </summary>
        [SugarColumn(ColumnDataType = "nvarchar(32)")]
        public string warehouse_code { get; set; }
        /// <summary>
        /// 仓库名称
        /// </summary>
        [SugarColumn(ColumnDataType = "nvarchar(20)")]
        public string warehouse_name { get; set; }
        /// <summary>
        /// 负责人ID
        /// </summary>
        public int principal_ID { get; set; }
        /// <summary>
        /// 负责人
        /// </summary>
        [Navigate(NavigateType.OneToOne, nameof(principal_ID))]
        public User principal_ { get; set; }
        /// <summary>
        /// 建库日期
        /// </summary>
        public DateTime construct_date { get; set; }
        /// <summary>
        /// 最大容量
        /// </summary>
        public int capacity { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [SugarColumn(IsNullable = true,ColumnDataType = "nvarchar(1000)")]
        public string? remark { get; set; }
    }
}
