using CoreLogic.Models;
using CoreLogic.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;

namespace WebApp.Pages
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public Employee Employee { get; set; }
        
        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                EmployeeService EmployeeService = new EmployeeService();

                // Make sure the Product object is not null before calling AddProduct
                if (Employee != null)
                {
                    EmployeeService.UpdateEmployee(Employee);
                    
                }

                return RedirectToPage("./Index");
            }
            else
            {
                return Page();
            }
        }

    }
}
