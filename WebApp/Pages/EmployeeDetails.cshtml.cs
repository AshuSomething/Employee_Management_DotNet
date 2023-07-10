using CoreLogic.Models;
using CoreLogic.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages
{
    public class EmployeeDetailsModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string id { get; set; }
        public Employee employee { get; set; }
        
        public void OnGet()
        {
            EmployeeService employeeService = new EmployeeService();
            employee = employeeService.GetEmployee(id);
        }
    }
}
