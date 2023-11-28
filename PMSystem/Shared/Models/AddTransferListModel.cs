using PMSystem.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMSystem.Shared.Models
{
    public class AddTransferListModel
    {
        public int id { get; set; }
        public string transfer_code { get; set; }
        public DateTime? transfer_date { get; set; }
        public PartsModel parts_ { get; set; }
        public int count { get; set; }
        public WarehouseModel out_warehouse_ { get; set; }
        public WarehouseModel in_warehouse_ { get; set; }
        public UserModel handle_ { get; set; }
        public string? remark { get; set; }
        public string? suggestion { get; set; }
        public TransferState? transfer_state { get; set; }
    }
}
