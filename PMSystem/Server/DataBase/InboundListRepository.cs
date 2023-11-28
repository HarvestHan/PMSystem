namespace PMSystem.Server.DataBase
{
    /// <summary>
    /// 入库单仓储
    /// </summary>
    public class InboundListRepository:MyClient<InboundList>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="context"></param>
        public InboundListRepository(ISqlSugarClient context) : base(context)
        {
            this.Context = context;
        }

        /// <summary>
        /// 导航查询入库单
        /// </summary>
        /// <returns></returns>
        public async Task<List<InboundList>> GetListNavAsync()
        {
            return await this.Context.Queryable<InboundList>()
                .Includes(i => i.warehouse_,w => w.principal_)
                .Includes(i => i.parts_)
                .Includes(i => i.handle_)
                .Where(i => !i.is_delete).ToListAsync();
        }

        /// <summary>
        /// 导航新增入库单
        /// </summary>
        /// <param name="inboundList"></param>
        /// <returns></returns>
        public async Task<bool> InsertNavAsync(InboundList inboundList)
        {
            return await this.Context.InsertNav(inboundList)
                .Include(i => i.warehouse_)
                .Include(i => i.parts_)
                .Include(i => i.handle_)
                .ExecuteCommandAsync();
        }

        /// <summary>
        /// 更新入库单
        /// </summary>
        /// <param name="inboundList"></param>
        /// <returns></returns>
        public async Task<bool> UpdateNavAsync(InboundList inboundList)
        {
            return await this.Context.UpdateNav(inboundList)
                .Include(i => i.warehouse_)
                .Include(i => i.parts_)
                .Include(i => i.handle_)
                .ExecuteCommandAsync();
        }
    }
}
