namespace PMSystem.Server.DataBase
{
    public class StorageInfoRepository:SimpleClient<StorageInfo>
    {
        public StorageInfoRepository(ISqlSugarClient context) : base(context)
        {
            this.Context = context;
        }

        /// <summary>
        /// 导航查询库内信息
        /// </summary>
        /// <returns></returns>
        public async Task<List<StorageInfo>> GetListNavAsync()
        {
            return await this.Context.Queryable<StorageInfo>()
                .Includes(i => i.warehouse_)
                .Includes(i => i.parts_)
                .ToListAsync();
        }

        public async Task<bool> Delete(List<int> IDlist,int Quantity)
        {
            var record = new StorageInfo() { warehouse_id = IDlist[0], parts_id = IDlist[1], count = Quantity };
            return await this.Context.Deleteable(record).ExecuteCommandAsync() > 0;
        }

        public async Task<bool> InsertNavAsync(List<int> IDlist, int Quantity)
        {
            var record = new StorageInfo() { warehouse_id = IDlist[0], parts_id = IDlist[1], count = Quantity };
            return await this.Context.Insertable(record).ExecuteCommandAsync() > 0;
        }

        /// <summary>
        /// 通过ID导航查询存储信息
        /// </summary>
        /// <returns></returns>
        public async Task<StorageInfo> GetNavByIDAsync(int Wno,int Pno)
        {
            return await this.Context.Queryable<StorageInfo>()
                .Includes(s => s.warehouse_)
                .Includes(s => s.parts_)
                .Where(s => s.warehouse_id == Wno && s.parts_id == Pno)
                .FirstAsync();
        }
    }
}
