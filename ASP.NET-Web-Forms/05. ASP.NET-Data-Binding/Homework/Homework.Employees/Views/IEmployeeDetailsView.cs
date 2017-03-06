using Homework.Employees.EventsArgs;
using Homework.Employees.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace Homework.Employees.Views
{
    public interface IEmployeeDetailsView : IView<EmployeeDetailsViewModel>
    {
        event EventHandler<DisplayEmployeeDetailsEventArgs> DisplayEmployeeDetails;
    }
}
