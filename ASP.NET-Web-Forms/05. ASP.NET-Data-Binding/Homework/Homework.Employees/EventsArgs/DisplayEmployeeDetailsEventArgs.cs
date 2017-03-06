using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.Employees.EventsArgs
{
    public class DisplayEmployeeDetailsEventArgs : EventArgs
    {
        public DisplayEmployeeDetailsEventArgs(string employeeId)
        {
            this.EmployeeId = employeeId;
        }

        public string EmployeeId { get; set; }
    }
}
