namespace PMSystem.Server.DataBase
{
    /// <summary>
    /// 出库单仓储
    /// </summary>
    public class OutboundListRepository:MyClient<OutboundList>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="context"></param>
        public OutboundListRepository(ISqlSugarClient context = null) : base(context)
        {
            base.Context = context;
        }

        /// <summary>
        /// 导航查询出库单
        /// </summary>
        /// <returns></returns>
        public async Task<List<OutboundList>> GetListNavAsync()
        {
            return await this.Context.Queryable<OutboundList>()
                .Includes(o => o.warehouse_,w => w.principal_)
                .Includes(o => o.parts_)
                .Includes(o => o.handle_)
                .Where(o => !o.is_delete).ToListAsync();
        }

        /// <summary>
        /// 导航新增出库单
        /// </summary>
        /// <param name="outboundList"></param>
        /// <returns></returns>
        public async Task<bool> InsertNavAsync(OutboundList outboundList)
        {
            return await this.Context.InsertNav(outboundList)
                .Include(i => i.warehouse_)
                .Include(i => i.parts_)
                .Include(i => i.handle_)
                .ExecuteCommandAsync();
        }

        /// <summary>
        /// 更新出库单
        /// </summary>
        /// <param name="outboundList"></param>
        /// <returns></returns>
        public async Task<bool> UpdateNavAsync(OutboundList outboundList)
        {
            return await this.Context.UpdateNav(outboundList)
                .Include(o => o.warehouse_)
                .Include(o => o.parts_)
                .Include(o => o.handle_).ExecuteCommandAsync();
        }
    }
}
