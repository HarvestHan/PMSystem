using Newtonsoft.Json;
using PMSystem.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PMSystem.Shared.Models
{
    public class UserModel
    {
        public int id { get; set; }
        public string user_code { get; set; }
        public string user_password { get; set; }
        public string user_name { get; set; }
        public string sex { get; set; }
        public string phone { get; set; }
        public List<RoleModel> Roles { get; set; }
        public override string ToString()
        {
            return user_name;
        }
    }
}
