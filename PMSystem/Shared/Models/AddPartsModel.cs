using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMSystem.Shared.Models
{
    public class AddPartsModel
    {
        public int id { get; set; }
        public string parts_code { get; set; }
        public string parts_name { get; set; }
        public string specification { get; set; }
        public string color { get; set; }
        public string unit { get; set; }
        public int volume { get; set; }
        public int weight { get; set; }
        public string? remark { get; set; }

        public override string ToString()
        {
            return parts_name;
        }
    }
}
