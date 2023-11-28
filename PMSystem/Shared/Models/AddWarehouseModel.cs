using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PMSystem.Shared.Models
{
    public class AddWarehouseModel
    {
        public int id { get; set; }
        public string warehouse_code { get; set; }
        public string warehouse_name { get; set; }
        public UserModel principal_ { get; set; }
        public DateTime? construct_date { get; set; }
        public int capacity { get; set; }
        public string? remark { get; set; }

        public override string ToString()
        {
            return warehouse_name;
        }
    }
}
