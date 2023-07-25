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
            EmployeeService employeeService = new EmployeeService();
            var roles = employeeService.GetRoles();
            PopulateRolesDropDown();
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {

                
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