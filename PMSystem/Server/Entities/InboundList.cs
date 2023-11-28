using Nextended.Core.Types;
using System.Data.SqlTypes;
using PMSystem.Shared.Enums;

namespace PMSystem.Server.Entities
{
    /// <summary>
    /// 入库单实体
    /// </summary>
    public class InboundList:BaseEntity
    {
        /// <summary>
        /// 入库单编号
        /// </summary>
        [SugarColumn(ColumnDataType = "nvarchar(20)")]
        public string inbound_code { get; set; }
        /// <summary>
        /// 入库日期
        /// </summary>
        public DateTime inbound_date { get; set; }
        /// <summary>
        /// 存储仓库ID
        /// </summary>
        public int warehouse_ID { get; set; }
        [Navigate(NavigateType.OneToOne, nameof(warehouse_ID))]
        public Warehouse warehouse_ { get; set; }
        /// <summary>
        /// 入库零件ID
        /// </summary>
        public int parts_ID { get; set; }
        [Navigate(NavigateType.OneToOne, nameof(parts_ID))]
        public Parts parts_ { get; set; }
        /// <summary>
        /// 入库数量
        /// </summary>
        public int count { get; set; }
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
        /// 零件入库状态
        /// </summary>
        public InboundState inbound_state { get; set; }
    }
}
