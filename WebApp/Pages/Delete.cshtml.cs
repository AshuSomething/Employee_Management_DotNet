using CoreLogic.Models;
using CoreLogic.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages
{
    public class DeleteModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int EmployeeId { get; set; }

        public Employee Employee { get; set; }

        public IActionResult OnGet()
        {
            // Fetch the employee from the database using the EmployeeId
            EmployeeService employeeService = new EmployeeService();
            Employee = employeeService.GetEmployee(EmployeeId);

            if (Employee == null)
            {
                return RedirectToPage("./Index");
            }

            return Page();
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

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                EmployeeService employeeService = new EmployeeService();
                employeeService.DeleteEmployee(EmployeeId);

                return RedirectToPage("./Index");
            }
            else
            {
                return Page();
            }
        }
    }
}
