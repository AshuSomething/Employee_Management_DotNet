using CoreLogic.Models;
using CoreLogic.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages
{
    [Authorize(Policy = "AdminOnly")]
    public class EmployeeListModel : PageModel
    {
        public List<Employee> employees { get; set; }
        public void OnGet()
        {
            EmployeeService employeeService = new EmployeeService();
            employees = employeeService.GetAllEmployees();
        }
    }
}