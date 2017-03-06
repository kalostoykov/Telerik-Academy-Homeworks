using Homework.Employees.EventsArgs;
using Homework.Employees.Presenters.Contracts;
using Homework.Employees.Services.Contracts;
using Homework.Employees.Views;
using System.Collections.Generic;
using WebFormsMvp;

namespace Homework.Employees.Presenters
{
    public class EmployeeDetailsPresenter : Presenter<IEmployeeDetailsView>, IEmployeeDetailsPresenter
    {
        private readonly IEmployeesService employeesService;
        private readonly IEmployeeDetailsView view;

        public EmployeeDetailsPresenter(IEmployeeDetailsView view, IEmployeesService employeesService)
            : base(view)
        {
            this.view = view;
            this.employeesService = employeesService;

            this.view.DisplayEmployeeDetails += OnDisplayEmployeeDetails;
        }

        private void OnDisplayEmployeeDetails(object sender, DisplayEmployeeDetailsEventArgs args)
        {
            int empId;
            var isParsed = int.TryParse(args.EmployeeId, out empId);

            if (isParsed)
            {
                this.view.Model.EmployeesWithId = this.employeesService.GetEmployeeById(empId);
            }
            else
            {
                this.view.Model.EmployeesWithId = new List<Employee>();
            }

        }
    }
}
