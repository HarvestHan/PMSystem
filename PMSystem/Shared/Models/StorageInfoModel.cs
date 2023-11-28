using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMSystem.Shared.Models
{
    public class StorageInfoModel
    {
        public WarehouseModel warehouse_ { get; set; }
        public PartsModel parts_ { get; set; }
        public int count { get; set; }
    }
}
