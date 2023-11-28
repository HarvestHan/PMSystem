using PMSystem.Shared.Enums;

namespace PMSystem.Server.Entities
{
    /// <summary>
    /// 盘点单实体
    /// </summary>
    public class CheckList:BaseEntity
    {
        /// <summary>
        /// 盘点单号
        /// </summary>
        [SugarColumn(ColumnDataType = "nvarchar(20)")]
        public string check_code { get; set; }
        /// <summary>
        /// 盘点日期
        /// </summary>
        public DateTime check_date { get; set; }
        /// <summary>
        /// 盘点仓库ID
        /// </summary>
        public int warehouse_ID { get; set; }
        /// <summary>
        /// 盘点仓库
        /// </summary>
        [Navigate(NavigateType.OneToOne, nameof(warehouse_ID))]
        public Warehouse warehouse_ { get; set; }
        /// <summary>
        /// 盘点零件ID
        /// </summary>
        public int parts_ID { get; set; }
        /// <summary>
        /// 盘点零件
        /// </summary>
        [Navigate(NavigateType.OneToOne, nameof(parts_ID))]
        public Parts parts_ { get; set; }
        /// <summary>
        /// 记录数量
        /// </summary>
        public int storage_count { get; set; }
        /// <summary>
        /// 盘点数量
        /// </summary>
        public int check_count { get; set; }
        /// <summary>
        /// 盘点人ID
        /// </summary>
        public int handle_ID { get; set; }
        /// <summary>
        /// 盘点人
        /// </summary>
        [Navigate(NavigateType.OneToOne, nameof(handle_ID))]
        public User handle_ { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [SugarColumn(IsNullable = true,ColumnDataType = "nvarchar(1000)")]
        public string? remark { get; set; }
        /// <summary>
        /// 审核意见
        /// </summary>
        [SugarColumn(IsNullable = true, ColumnDataType = "nvarchar(1000)")]
        public string? suggestion { get; set; }
        /// <summary>
        /// 盘点状态
        /// </summary>
        public CheckState check_state { get; set; }
    }
}

