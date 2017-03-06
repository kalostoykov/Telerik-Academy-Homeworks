using Homework.Employees.Presenters.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;
using Homework.Employees.Views;
using Homework.Employees.Services.Contracts;

namespace Homework.Employees.Presenters
{
    public class EmployeesPresenter : Presenter<IEmployeesView>, IEmployeesPresenter
    {
        private readonly IEmployeesService employeesService;
        private readonly IEmployeesView view;

        public EmployeesPresenter(IEmployeesView view, IEmployeesService employeesService)
            : base(view)
        {
            this.view = view;
            this.view.DisplayAllEmployees += OnDisplayLoad;

            this.employeesService = employeesService;
        }

        private void OnDisplayLoad(object sender, EventArgs args)
        {
            this.view.Model.AllEmployees = this.employeesService.GetAllEmployeesNames();
        }
    }
}
