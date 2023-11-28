using NPOI.SS.Formula.Functions;
using PMSystem.Server.Entities;
using PMSystem.Shared.Models;

namespace PMSystem.Server.DataBase
{
    /// <summary>
    /// 用户仓储
    /// </summary>
    public class UserRepository : MyClient<User>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="context"></param>
        public UserRepository(ISqlSugarClient context = null) : base(context)
        {
            base.Context = context;
        }

        /// <summary>
        /// 插入用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<bool> InsertNavAsync(User user)
        {
            return await this.Context.InsertNav(user)
                .Include(u => u.Roles)
                .ExecuteCommandAsync();
        }

        /// <summary>
        /// 通过RoleID获取用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<List<User>> GetListByRoleIDAsync(int id)
        {
            var list = await this.Context.Queryable<User>()
                .Includes(u => u.Roles)
                .ToListAsync();
            return list.FindAll(u => u.Roles.Where(role => role.id == id).ToList().Count > 0)
                .Where(u=>!u.is_delete).ToList();
        }

        /// <summary>
        /// 通过账号获取用户
        /// </summary>
        /// <param name="Code"></param>
        /// <returns></returns>
        public async Task<List<User>> GetListByCodeAsync(string Code)
        {
            return await this.Context.Queryable<User>()
                .Where(u => u.user_code == Code)
                .Includes(u => u.Roles)
                .Where(u => !u.is_delete)
                .ToListAsync();
        }

        /// <summary>
        /// 导航查询用户
        /// </summary>
        /// <returns></returns>
        public async Task<List<User>> GetListNavAsync()
        {
            return await this.Context.Queryable<User>()
                .Includes(u => u.Roles)
                .Where(u => !u.is_delete).ToListAsync();
        }

        /// <summary>
        /// 通过ID导航查询用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<User> GetNavByIDAsync(int id)
        {
            return await this.Context.Queryable<User>()
                .Includes(u => u.Roles)
                .Where(u => u.id == id)
                .Where(u => !u.is_delete)
                .FirstAsync();
        }

        /// <summary>
        /// 更新用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<bool> UpdateNavAsync(User user)
        {
            return await this.Context.UpdateNav(user)
                .Include(u => u.Roles).ExecuteCommandAsync();
        }

        public async Task<User> GetAllUserInfo(int id)
        {
            return await this.Context.Queryable<User>()
                .Includes(u => u.Roles)
                .Where(u => u.id == id)
                .Where(u => !u.is_delete)
                .FirstAsync();
        }

        public async Task<List<User>> GetByIDListAsync(List<int> userID)
        {
            var list = new List<User>();
            foreach (var id in userID)
            {
                var result = await this.GetByIdAsync(id);
                list.Add(result);
            }
            return list;
        }
    }
}
