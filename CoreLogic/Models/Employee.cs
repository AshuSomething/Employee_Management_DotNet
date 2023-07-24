using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLogic.Models
{
    public class Employee
    {
        IEnumerable<Attandance> Attandances { get; set; }
        public Employee()
        {
            Attandances = new HashSet<Attandance>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Roles { get; set; }
    }

}
