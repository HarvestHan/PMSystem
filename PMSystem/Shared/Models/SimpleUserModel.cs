using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PMSystem.Shared.Models
{
	public class SimpleUserModel
	{
		public int id { get; set; }
		public string user_name { get; set; }
		public override string ToString()
		{
			return user_name;
		}
	}
}
