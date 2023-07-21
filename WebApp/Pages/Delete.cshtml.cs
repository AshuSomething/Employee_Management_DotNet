using CoreLogic.Models;
using CoreLogic.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages
{
    public class DeleteModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string id { get; set; }
        public Employee employee { get; set; }

        public void OnGet()
        {
            EmployeeService employeeService = new EmployeeService();
            employee = employeeService.GetEmployee(id);
        }

        /* public IActionResult OnGet()
         {
             // Fetch the employee from the database using the Id
             Employee = _employeeService.GetEmployeeById(Id);

             if (Employee == null)
             {
                 return RedirectToPage("./Index");
             }

             return Page();
         }*/
        
        /*public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {

                string EmployeeId = Convert.ToString(Employee.Id);
                EmployeeService employeeService = new EmployeeService();
                employeeService.DeleteEmployee(EmployeeId);

                return RedirectToPage("./Index");
            }
            else
            {
                return Page();
            }
        }*/
    }
}
