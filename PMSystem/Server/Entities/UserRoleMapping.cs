namespace PMSystem.Server.Entities
{
    /// <summary>
    /// 用户权限映射表
    /// </summary>
    public class UserRoleMapping
    {
        /// <summary>
        /// 对应的用户ID
        /// </summary>
        [SugarColumn(IsPrimaryKey = true)]
        public int user_id { get; set; }
        /// <summary>
        /// 对应的权限ID
        /// </summary>
        [SugarColumn(IsPrimaryKey = true)]
        public int role_id { get; set; }
    }
}
