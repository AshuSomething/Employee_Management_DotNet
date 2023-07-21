using CoreLogic.Models;
using CoreLogic.Services;
using EFGetStarted;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages
{
    public class DeleteModel : PageModel
    {
        private MyContext _context;
        public DeleteModel(MyContext ctx)
        {
            _context = ctx;
        }
        [BindProperty(SupportsGet = true)]
        public string id { get; set; }

        [BindProperty]
        public Employee Employee { get; set; }
        
       /* public void OnGet()
        {
            EmployeeService employeeService = new EmployeeService();
            Employee = employeeService.GetEmployee(id);
        }*/

        public IActionResult OnGet()
        {
            // Fetch the employee from the database using the Id
            EmployeeService employeeService = new EmployeeService();
            Employee = employeeService.GetEmployee(id);

            if (Employee == null)
            {
                return RedirectToPage("./Index");
            }

            return Page();
        }


        public IActionResult OnPost(string id)
        {
            if (ModelState!= null)
            {
                //string id = Convert.ToString(Employee.Id);
                EmployeeService employeeService = new EmployeeService();
                employeeService.DeleteEmployee(id); // Access Employee.Id directly

                return RedirectToPage("./Index");
            }
            else
            {
                return Page();
            }
        }

    }
}
