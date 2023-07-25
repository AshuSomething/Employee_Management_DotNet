using CoreLogic.Models;
using EFGetStarted;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLogic.Services
{
    public class DeletedEmployeeService
    {

		public List<DeletedEmployee> GetDeletedEmployees()
		{
			MyContext ctx = new MyContext();

			var DeletedEmployees = ctx.DeletedEmployees.ToList();

			return DeletedEmployees ?? new List<DeletedEmployee>();
		}

	}
}
