using CoreLogic.Models;
using EFGetStarted;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLogic.Services
{
    public class AttendanceService
    {
        public List<Attandance> GetAllAttendances()
        {
            MyContext   ctx = new MyContext();  

            var attendances = ctx.Attandances.ToList();

            return attendances;

        }

        public Attandance GetAttandanceById(int id) 
        
        { 
            MyContext ctx = new MyContext();

            return ctx.Attandances.SingleOrDefault(x => x.Id == id);

        }
        public List<Attandance> GetAttendancesByDate(DateTime date)
        {
            MyContext ctx = new MyContext();

            var attendances = ctx.Attandances.Where(a => a.Date.Date == date.Date).ToList();

            return attendances;
        }



    }
}
