namespace PMSystem.Server.DataBase
{
    /// <summary>
    /// 仓库仓储
    /// </summary>
    public class WarehouseRepository:MyClient<Warehouse>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="context"></param>
        public WarehouseRepository(ISqlSugarClient context) : base(context)
        {
            this.Context = context;
        }

        /// <summary>
        /// 导航查询仓库
        /// </summary>
        /// <returns></returns>
        public async Task<List<Warehouse>> GetListNavAsync()
        {
            return await this.Context.Queryable<Warehouse>()
                .Includes(u => u.principal_)
                .Where(u => !u.is_delete).ToListAsync();
        }

        /// <summary>
        /// 导航更新仓库
        /// </summary>
        /// <param name="warehouse"></param>
        /// <returns></returns>
        public async Task<bool> UpdateNavAsync(Warehouse warehouse)
        {
            return await this.Context.UpdateNav(warehouse)
                .Include(d => d.principal_)
                .ExecuteCommandAsync();
        }
    }
}
