using CoreLogic.Models;
using CoreLogic.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages
{
    public class CreateModel : PageModel
    {

        [BindProperty]
        public Employee employee { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }



        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                EmployeeService productService = new EmployeeService();

                // Make sure the Product object is not null before calling AddProduct
                if (employee != null)
                {
                    productService.AddEmployee(employee);
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