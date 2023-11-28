using Nextended.Core.Types;
using System.Data.SqlTypes;
using PMSystem.Shared.Enums;

namespace PMSystem.Server.Entities
{
    /// <summary>
    /// 调拨单实体
    /// </summary>
    public class TransferList:BaseEntity
    {
        /// <summary>
        /// 调拨单编号
        /// </summary>
        [SugarColumn(ColumnDataType = "nvarchar(20)")]
        public string transfer_code { get; set; }
        /// <summary>
        /// 调拨日期
        /// </summary>
        public DateTime transfer_date { get; set; }
        /// <summary>
        /// 调拨零件ID
        /// </summary>
        public int parts_ID { get; set; }
        /// <summary>
        /// 零件
        /// </summary>
        [Navigate(NavigateType.OneToOne, nameof(parts_ID))]
        public Parts parts_ { get; set; }
        /// <summary>
        /// 调拨数量
        /// </summary>
        public int count { get; set; }
        /// <summary>
        /// 转出仓库ID
        /// </summary>
        public int out_warehouse_ID { get; set; }
        /// <summary>
        /// 转出仓库
        /// </summary>
        [Navigate(NavigateType.OneToOne, nameof(out_warehouse_ID))]
        public Warehouse out_warehouse_ { get; set; }
        /// <summary>
        /// 转入仓库ID
        /// </summary>
        public int in_warehouse_ID { get; set; }
        /// <summary>
        /// 转入仓库
        /// </summary>
        [Navigate(NavigateType.OneToOne, nameof(in_warehouse_ID))]
        public Warehouse in_warehouse_ { get; set; }
        /// <summary>
        /// 处理人ID
        /// </summary>
        public int handle_ID { get; set; }
        /// <summary>
        /// 处理人
        /// </summary>
        [Navigate(NavigateType.OneToOne, nameof(handle_ID))]
        public User handle_ { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [SugarColumn(IsNullable = true, ColumnDataType = "nvarchar(1000)")]
        public string? remark { get; set; }
        /// <summary>
        /// 审核意见
        /// </summary>
        [SugarColumn(IsNullable = true, ColumnDataType = "nvarchar(1000)")]
        public string? suggestion { get; set; }
        /// <summary>
        /// 调拨状态
        /// </summary>
        public TransferState transfer_state { get; set; }
    }
}
