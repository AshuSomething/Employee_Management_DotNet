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

                if (existingAttendance != null)
                {
                    // Employee already checked in today, update the login time
                    existingAttendance.LoginTime = loginTime;
                    ctx.SaveChanges();
                }
                else
                {
                    // Employee is checking in for the first time today, create a new attendance record
                    var newAttendance = new Attandance
                    {
                        EmployeeId = employeeId,
                        Date = DateTime.Today,
                        Status = true, // Assuming 'true' means 'present' or 'checked in'
                        LoginTime = loginTime,
                        LogoutTime = new DateTime(2000, 1, 1), // Initial default value for LogoutTime
                        WorkingHour = TimeSpan.Zero // Initial default value for WorkingHour
                    };

                    ctx.Attandances.Add(newAttendance);
                    ctx.SaveChanges();
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
                    // Update the logout time
                    existingAttendance.LogoutTime = logoutTime;

                    // Calculate the working hours
                    existingAttendance.WorkingHour = existingAttendance.LogoutTime - existingAttendance.LoginTime;

                    ctx.SaveChanges();
                }
                else
                {
                    throw new InvalidOperationException("You are not logged in. Please check in before attempting to check out.");

                }
            }

        }
    }
}