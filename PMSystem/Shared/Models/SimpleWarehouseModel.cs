using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMSystem.Shared.Models
{
    public class SimpleWarehouseModel
    {
        public int id { get; set; }
        public string warehouse_name { get; set; }
        //public int WprincipalID { get; set; }
        public override string ToString()
        {
            return warehouse_name;
        }
    }
}
