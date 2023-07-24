using CoreLogic.Models;
using CoreLogic.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace WebApp.Pages
{
    [Authorize]
    public class EmployeeDetailsModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string id { get; set; }
        public Employee employee { get; set; }
        public string message { get; set; }
        public IActionResult OnGet()
        {
            EmployeeService employeeService = new EmployeeService();
            employee = employeeService.GetEmployee(id);
            if (id != User.Identity.Name)
            {
                return Redirect("/AccessDenied");
            }
            return Page();
        }

        public void OnPostCheckIn(string id)
        {
            EmployeeService employeeService = new EmployeeService();
            employee = employeeService.GetEmployee(id);
            int int_id = Convert.ToInt32(id);
            CheckInCheckOutService checkInCheckOutService = new CheckInCheckOutService();
            DateTime checkInDate = DateTime.Now;
            
            try
            {
                checkInCheckOutService.CheckIn(int_id, checkInDate);
            }
            catch (Exception e)
            {
                message = e.Message;
                return;
            }
            message = "You hvae succesfully checked in";
        }

        public void OnPostCheckout(string id)
        {
            EmployeeService employeeService = new EmployeeService();
            employee = employeeService.GetEmployee(id);
            int int_id = Convert.ToInt32(id);
            CheckInCheckOutService checkInCheckOutService = new CheckInCheckOutService();
            DateTime checkOutDate = DateTime.Now;
            try
            {
                checkInCheckOutService.CheckOut(int_id, checkOutDate);
            }
            catch (Exception e)
            {
                message = e.Message;
                return;
            }
            message = "You hvae succesfully checked out";
        }
    }
}
