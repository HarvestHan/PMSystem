namespace PMSystem.Server.DataBase
{
    /// <summary>
    /// 调拨单仓储
    /// </summary>
    public class TransferListRepository:MyClient<TransferList>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="context"></param>
        public TransferListRepository(ISqlSugarClient context = null) : base(context)
        {
            base.Context = context;
        }

        /// <summary>
        /// 导航查询调拨单
        /// </summary>
        /// <returns></returns>
        public async Task<List<TransferList>> GetListNavAsync()
        {
            return await this.Context.Queryable<TransferList>()
                .Includes(t => t.parts_)
                .Includes(t => t.in_warehouse_,w => w.principal_)
                .Includes(t => t.out_warehouse_, w => w.principal_)
                .Includes(t => t.handle_)
                .Where(i => !i.is_delete).ToListAsync();
        }

        /// <summary>
        /// 导航新增调拨单
        /// </summary>
        /// <param name="transferList"></param>
        /// <returns></returns>
        public async Task<bool> InsertNavAsync(TransferList transferList)
        {
            return await this.Context.InsertNav(transferList)
                .Include(t => t.parts_)
                .Include(t => t.in_warehouse_)
                .Include(t => t.out_warehouse_)
                .Include(t => t.handle_)
                .ExecuteCommandAsync();
        }

        /// <summary>
        /// 更新调拨单
        /// </summary>
        /// <param name="transferList"></param>
        /// <returns></returns>
        public async Task<bool> UpdateNavAsync(TransferList transferList)
        {
            return await this.Context.UpdateNav(transferList)
                .Include(t => t.parts_)
                .Include(t => t.in_warehouse_)
                .Include(t => t.out_warehouse_)
                .Include(t => t.handle_)
                .ExecuteCommandAsync();
        }
    }
}
