using CoreLogic.Models;
using EFGetStarted;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLogic.Services
{
    public class EmployeeService
    {
        public List<Employee> GetAllEmployees()
        {
            MyContext ctx = new MyContext();

            var Employees = ctx.Employees.ToList();

            return Employees;
        }

        public Employee GetEmployee(string id_as_string)
        {
            int id = Convert.ToInt32(id_as_string);
            using (MyContext ctx = new MyContext())
            {
                var Employee = ctx.Employees.Find(id);
                return Employee;
            }
        }

        public void AddEmployee(Employee employee)
        {
            using (MyContext ctx = new MyContext())
            {
                ctx.Employees.Add(employee);
                ctx.SaveChanges();
            }
        }
        public void UpdateEmployee(Employee updatedEmployee)
        {
            using (MyContext ctx = new MyContext())
            {
                var existingEmployee = ctx.Employees.Find(updatedEmployee.Id);

                if (existingEmployee != null)
                {
                    // Update the properties of the existing product
                    existingEmployee.Name = updatedEmployee.Name;
                    existingEmployee.Email = updatedEmployee.Email;
                    existingEmployee.Password = updatedEmployee.Password;
                    //existingProduct.Id = updatedProduct.Id;

                    ctx.SaveChanges();
                }
            }
        }

        public void DeleteEmployee(string id_as_string)
        {
            int employeeId = Convert.ToInt32(id_as_string);

            using (MyContext ctx = new MyContext())
            {
                Employee employeeToDelete = ctx.Employees.Find(employeeId);

                if (employeeToDelete != null)
                {
                    // Transfer the data to DeletedEmployees table
                    TransferToDeletedEmployees(ctx, employeeToDelete);

                    // Remove the employee from Employees table
                    ctx.Employees.Remove(employeeToDelete);

                    ctx.SaveChanges();
                }
            }
        }

        private void TransferToDeletedEmployees(MyContext ctx, Employee employeeToDelete)
        {
            // Create a new DeletedEmployee object with the data from the employee to be deleted
            var deletedEmployee = new DeletedEmployee
            {
                Name = employeeToDelete.Name,
                Email = employeeToDelete.Email,
                Password = employeeToDelete.Password
            };

            // Add the new DeletedEmployee to the DeletedEmployees table
            ctx.DeletedEmployees.Add(deletedEmployee);
        }

        public List<Role> GetRoles()
        {
            MyContext ctx = new MyContext();
            return ctx.Roles.ToList();
        }
    }
}
