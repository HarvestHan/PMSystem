namespace PMSystem.Server.DataBase
{
    /// <summary>
    /// 零件仓储
    /// </summary>
    public class PartsRepository:MyClient<Parts>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="context"></param>
        public PartsRepository(ISqlSugarClient context) : base(context)
        {
            this.Context = context;
        }

        /// <summary>
        /// 导航查询零件
        /// </summary>
        /// <returns></returns>
        public async Task<List<Parts>> GetListNavAsync()
        {
            return await this.Context.Queryable<Parts>()
                .Where(u => !u.is_delete).ToListAsync();
        }
    }
}
