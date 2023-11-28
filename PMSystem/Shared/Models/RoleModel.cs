using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMSystem.Shared.Enums;

namespace PMSystem.Shared.Models
{
    public class RoleModel
    {
        public int id { get; set; }
        public RoleType role_type { get; set; }
        public string RealName =>
            role_type switch
            {
                RoleType.Admin=>"系统管理员",
                RoleType.Supervisor => "仓库主管",
                RoleType.InboundClerk=>"仓库入库员",
                RoleType.Keeper=>"仓库管理员",
                RoleType.OutboundClerk=>"仓库出库员",
                RoleType.User =>"普通员工",
                RoleType.None => "空",
                _=>"None"
            };

        public override string ToString()
        {
            return RealName;
        }
    }
}
