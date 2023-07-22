using CoreLogic.Models;
using EFGetStarted;
using System;
using System.Linq;

namespace CoreLogic.Services
{
    public class CheckInCheckOutService
    {

        public void CheckIn(int employeeId, DateTime loginTime)
        {
            using (MyContext ctx = new MyContext())
            {
                // Check if there is an existing attendance for the employee on the current date
                var existingAttendance = ctx.Attandances
                    .FirstOrDefault(a => a.EmployeeId == employeeId && a.Date.Date == DateTime.Today);

                if (existingAttendance == null)
                {
                    var newAttendance = new Attandance
                    {
                        EmployeeId = employeeId,
                        Date = DateTime.Today,
                        Status = true, // Assuming 'true' means 'present' or 'checked in'
                        LoginTime = loginTime,
                        LogoutTime = null, // Initial default value for LogoutTime
                        WorkingHour = null // Initial default value for WorkingHour
                    };

                    ctx.Attandances.Add(newAttendance);
                    ctx.SaveChanges();
                }
                else
                {
                    throw new Exception("You have already checked in for the day");
                }
            }
            
        }
        public void CheckOut(int employeeId, DateTime logoutTime)
        {
            using (MyContext ctx = new MyContext())
            {
                // Find the attendance record for the employee on the current date
                var existingAttendance = ctx.Attandances
                    .FirstOrDefault(a => a.EmployeeId == employeeId && a.Date.Date == DateTime.Today);

                if (existingAttendance != null)
                {
                    if(existingAttendance.LogoutTime != null)
                    {
                        throw new Exception("you have checked out for the day");
                    }
                    // Update the logout time
                    existingAttendance.LogoutTime = logoutTime;

                    // Calculate the working hours
                    existingAttendance.WorkingHour = existingAttendance.LogoutTime - existingAttendance.LoginTime;

                    ctx.SaveChanges();
                }
                else
                {
                    throw new Exception("please check in first");
                }
            }

        }
    }
}