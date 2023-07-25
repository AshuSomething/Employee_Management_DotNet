using CoreLogic.Models;
using CoreLogic.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.Pages
{
    public class CreateModel : PageModel
    {

        [BindProperty]
        public Employee employee { get; set; }

        public List<SelectListItem> RoleOptions { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }



        /*public IActionResult OnPost()
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
*/

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {

                PopulateRolesDropDown();
                return Page();
            }
            EmployeeService productService = new EmployeeService();

            productService.AddEmployee(employee);
            return RedirectToPage("./Index");
        }

        public void PopulateRolesDropDown()
        {
            EmployeeService employeeService = new EmployeeService();

            var categories = employeeService.GetRoles();

            RoleOptions = categories.Select(role =>
                                      new SelectListItem
                                      {
                                          Value = role.Id.ToString(),
                                          Text = role.Name
                                      }).ToList();
        }

    }
}