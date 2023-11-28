namespace PMSystem.Server.DataBase
{
    /// <summary>
    /// 盘点单仓储
    /// </summary>
    public class CheckListRepository:MyClient<CheckList>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="context"></param>
        public CheckListRepository(ISqlSugarClient context) : base(context)
        {
            this.Context = context;
        }

        /// <summary>
        /// 导航查询盘点单
        /// </summary>
        /// <returns></returns>
        public async Task<List<CheckList>> GetListNavAsync()
        {
            return await this.Context.Queryable<CheckList>()
                .Includes(c => c.warehouse_,w => w.principal_)
                .Includes(c => c.parts_)
                .Includes(c => c.handle_)
                .Where(c => !c.is_delete).ToListAsync();
        }

        /// <summary>
        /// 导航新增盘点单
        /// </summary>
        /// <param name="checkList"></param>
        /// <returns></returns>
        public async Task<bool> InsertNavAsync(CheckList checkList)
        {
            return await this.Context.InsertNav(checkList)
                .Include(i => i.warehouse_)
                .Include(i => i.parts_)
                .Include(i => i.handle_)
                .ExecuteCommandAsync();
        }

        /// <summary>
        /// 导航更新盘点单
        /// </summary>
        /// <param name="checkList"></param>
        /// <returns></returns>
        public async Task<bool> UpdateNavAsync(CheckList checkList)
        {
            return await this.Context.UpdateNav(checkList)
                .Include(c => c.warehouse_)
                .Include(c => c.parts_)
                .Include(c => c.handle_)
                .ExecuteCommandAsync();
        }
    }
}
