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

        public void DeleteEmployee(Employee updatedEmployee)
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
    }
}
