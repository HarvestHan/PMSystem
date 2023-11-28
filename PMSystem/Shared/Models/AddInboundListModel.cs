using PMSystem.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMSystem.Shared.Models
{
    public class AddInboundListModel
    {
        public int id { get; set; }
        public string inbound_code { get; set; }
        public DateTime? inbound_date { get; set; }
        public WarehouseModel warehouse_ { get; set; }
        public PartsModel parts_ { get; set; }
        public int count { get; set; }
        public UserModel handle_ { get; set; }
        public string? remark { get; set; }
        public string? suggestion { get; set; }
        public InboundState? inbound_state { get; set; }
    }
}
