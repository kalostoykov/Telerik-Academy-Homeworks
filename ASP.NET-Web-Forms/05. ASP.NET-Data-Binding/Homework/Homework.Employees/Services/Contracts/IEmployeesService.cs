using Homework.Employees.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.Employees.Services.Contracts
{
    public interface IEmployeesService
    {
        IEnumerable<EmployeeNames> GetAllEmployeesNames();

        IEnumerable<Employee> GetEmployeeById(int id);
    }
}
