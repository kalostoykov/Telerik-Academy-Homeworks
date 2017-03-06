using Homework.Employees.Models;
using Homework.Employees.ViewModels;
using System;
using WebFormsMvp;

namespace Homework.Employees.Views
{
    public interface IEmployeesView : IView<EmployeesViewModel>
    {
        event EventHandler DisplayAllEmployees;
    }
}
