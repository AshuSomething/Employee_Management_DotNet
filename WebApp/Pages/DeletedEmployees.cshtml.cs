using CoreLogic.Models;
using CoreLogic.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages
{
    public class DeletedEmployeesModel : PageModel
    {

        public List<DeletedEmployee> deletedEmployees { get; set; }
        public void OnGet()
        {
			DeletedEmployeeService deletedemployeeService = new DeletedEmployeeService();
			deletedEmployees = deletedemployeeService.GetDeletedEmployees();
		
		}
    }
}
