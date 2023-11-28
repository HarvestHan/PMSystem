using PMSystem.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMSystem.Shared.Models
{
    public class UpdateCheckListModel
    {
        public int id { get; set; }
        public string check_code { get; set; }
        public DateTime? check_date { get; set; }
        public WarehouseModel warehouse_ { get; set; }
        public PartsModel parts_ { get; set; }
        public int storage_count { get; set; }
        public int check_count { get; set; }
        public UserModel handle_ { get; set; }
        public string? remark { get; set; }
        public string? suggestion { get; set; }
        public CheckState? check_state { get; set; }
    }
}
