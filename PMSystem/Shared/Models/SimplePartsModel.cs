using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMSystem.Shared.Models
{
    public class SimplePartsModel
    {
        public int id { get; set; }
        public string parts_name { get; set; }
        public override string ToString()
        {
            return parts_name;
        }
    }
}
