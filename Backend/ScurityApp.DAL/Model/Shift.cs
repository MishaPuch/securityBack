using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScurityApp.DAL.Model
{
    public class Shift
    {
        public int Id { get; set; }
        public int EmployeeId {  get; set; }
        public int ShiftHours {  get; set; }

        public Employee Employee { get; set; }
        public WorkSchedule WorkSchedule{ get; set; }
    }
}
