using CoreLogic.Models;
using CoreLogic.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages
{
    public class IndexModel : PageModel
    {
        public List<Employee> employees { get; set; }

        public List<Attandance> Attendances { get; set; }
        public void OnGet()
        {
            EmployeeService employeeService = new EmployeeService();
            employees = employeeService.GetAllEmployees();


        }
    }
}