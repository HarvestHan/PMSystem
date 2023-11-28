namespace PMSystem.Server.Entities
{
    /// <summary>
    /// 零件实体
    /// </summary>
    public class Parts:BaseEntity
    {
        /// <summary>
        /// 零件编码
        /// </summary>
        [SugarColumn(ColumnDataType = "nvarchar(32)")]
        public string parts_code { get; set; }
        /// <summary>
        /// 零件名称
        /// </summary>
        [SugarColumn(ColumnDataType = "nvarchar(20)")]
        public string parts_name { get; set; }
        /// <summary>
        /// 零件规格
        /// </summary>
        [SugarColumn(ColumnDataType = "nvarchar(32)")]
        public string specification { get; set; }
        /// <summary>
        /// 零件颜色
        /// </summary>
        [SugarColumn(ColumnDataType = "nvarchar(20)")]
        public string color { get; set; }
        /// <summary>
        /// 计量单位
        /// </summary>
        [SugarColumn(ColumnDataType = "nvarchar(10)")]
        public string unit { get; set; }
        /// <summary>
        /// 零件体积
        /// </summary>
        public int volume { get; set; }
        /// <summary>
        /// 零件重量
        /// </summary>
        public int weight { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [SugarColumn(ColumnDataType = "nvarchar(1000)")]
        public string? remark { get; set; }
    }
}
