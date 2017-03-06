using Homework.Employees.Models;
using System.Collections.Generic;

namespace Homework.Employees.ViewModels
{
    public class EmployeesViewModel
    {
        public IEnumerable<EmployeeNames> AllEmployees { get; set; }
    }
}
