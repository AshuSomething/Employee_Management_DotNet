using CoreLogic.Models;
using EFGetStarted;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages.Attandances
{
    public class abcdModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        public List<Attandance> Attendances { get; set; }

        public List<Employee> EmployeesName { get; set; }


        public void OnGet()
        {
            int employeeId = Id; // Replace with the actual employee ID
            Attendances = GetAllAttendancesForId(employeeId);
            EmployeesName = GetNameForId(Id);
        }

        private List<Attandance> GetAllAttendancesForId(int employeeId)
        {
            // Retrieve the attendances from your data source (database, API, etc.)
            // Replace this with your actual data retrieval logic
            MyContext ctx = new MyContext();
            var attendances = ctx.Attandances.Where(a => a.EmployeeId == employeeId).ToList();

            return attendances;
        }

        private List<Employee> GetNameForId(int employeeId)
        {
            // Retrieve the attendances from your data source (database, API, etc.)
            // Replace this with your actual data retrieval logic
            MyContext ctx = new MyContext();
            var employee = ctx.Employees.Where(a => a.Id == Id).ToList();

            return employee;
        }


    }
}
