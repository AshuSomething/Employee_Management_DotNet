using CoreLogic.Models;
using EFGetStarted;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Attandances
{
    public class IndexModel : PageModel
    {
        public List<Attandance> Attendances { get; set; }

        public void OnGet()
        {
            // Load attendances for the employee
            int employeeId = 2; // Replace with the actual employee ID
            Attendances = GetAllAttendancesForEmployee(employeeId);
        }

        private List<Attandance> GetAllAttendancesForEmployee(int employeeId)
        {
            // Retrieve the attendances from your data source (database, API, etc.)
            // Replace this with your actual data retrieval logic
            MyContext ctx = new MyContext();
            var attendances = ctx.Attandances.Where(a => a.EmployeeId == employeeId).ToList();

            return attendances;
        }
    }
}
