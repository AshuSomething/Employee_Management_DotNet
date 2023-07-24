using CoreLogic.Models;
using Microsoft.EntityFrameworkCore;

namespace EFGetStarted
{
    public class MyContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Attandance> Attandances { get; set; }
        public DbSet<DeletedEmployee> DeletedEmployees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var server = "(localdb)";
            var instance = "mssqllocaldb";
            var database = "EmployeeManagementDB";
            var authentication = "Integrated Security = true";

            var conString = $"Data Source={server}\\{instance}; Initial Catalog={database};{authentication}";

            options.UseSqlServer(conString);
        }
    }
}