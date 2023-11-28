namespace PMSystem.Server.DataBase
{
    public class MyClient<T> : SimpleClient<T> where T : BaseEntity ,new()
    {
        public MyClient(ISqlSugarClient context) : base(context)
        {
            this.Context = context;
        }

        public override async Task<bool> DeleteByIdAsync(dynamic id)
        {
            T item = await GetByIdAsync(id);
            if (item is null)
            {
                return false;
            }
            item.is_delete = true;

            if (await UpdateAsync(item))
            {
                return true;
            }
            return false;
            
        }
    }
}
