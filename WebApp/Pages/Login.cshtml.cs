using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using CoreLogic.Models;
using CoreLogic.Services;

namespace WebApp.Pages;

public class LoginModel : PageModel
{
    [BindProperty]
    public string Id { get; set; }

    public async Task<IActionResult> OnPostAsync()
    {
        // Here you can validate the user credentials against your database
        // Retrieve the user from your database.
        EmployeeService employeeService = new EmployeeService();
        var user = employeeService.GetEmployee(Id);

        if (user == null)
        {
            // User with the given username doesn't exist.
            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return Page();
        }

        /*if (Password != user.Password)
        {
            // Passwords don't match.
            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return Page();
        }*/

        // User has provided valid credentials. Proceed with your login process...
        await SignInUser();

        return RedirectToPage("/Index");
    }

    private async Task SignInUser()
    {       
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, Id)
        };

        var claimsIdentity = new ClaimsIdentity(claims, "CookieAuth");

        var authProperties = new AuthenticationProperties();

        await HttpContext.SignInAsync("CookieAuth", new ClaimsPrincipal(claimsIdentity), authProperties);

    }
}

