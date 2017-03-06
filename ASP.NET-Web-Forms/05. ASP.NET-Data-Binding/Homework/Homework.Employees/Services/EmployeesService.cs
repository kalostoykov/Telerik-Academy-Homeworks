using Homework.Employees.Services.Contracts;
using System;
using System.Collections.Generic;
using Homework.Employees.Models;
using System.Linq;
using AutoMapper;
using System.Data.Entity.Core;

namespace Homework.Employees.Services
{
    public class EmployeesService : IEmployeesService
    {
        private readonly NorthwindEntities dbContext;

        public EmployeesService(NorthwindEntities dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<EmployeeNames> GetAllEmployeesNames()
        {
            try
            {
                return this.dbContext.Employees.ProjectToList<EmployeeNames>();
            }
            catch (EntityException)
            {
                return new EmployeeNames[] { };
            }
        }

        public IEnumerable<Employee> GetEmployeeById(int id)
        {
            try
            {
                return this.dbContext.Employees.Where(x => x.EmployeeID == id).ToList();
            }
            catch (EntityException)
            {
                return new Employee[] { };
            }
        }
    }
}
