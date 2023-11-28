namespace PMSystem.Server.Entities
{
    public class BaseEntity
    {
        /// <summary>
        /// 数据库ID
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int id { get; set; }

        public bool is_delete { get; set; } = false;
    }
}
