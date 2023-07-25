using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLogic.Models
{
	public class Role
	{
		IEnumerable<Employee> Employees { get; set; }
		public Role()
		{
			Employees = new HashSet<Employee>();
		}
		public int Id { get; set; }

		public string Name { get; set; }
	}
}
