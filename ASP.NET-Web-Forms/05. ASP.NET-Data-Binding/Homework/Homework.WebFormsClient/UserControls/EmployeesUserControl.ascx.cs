using Homework.Employees.Presenters.Contracts;
using Homework.Employees.ViewModels;
using Homework.Employees.Views;
using System;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace Homework.WebFormsClient.UserControls
{
    [PresenterBinding(typeof(IEmployeesPresenter))]
    public partial class EmployeesUserControl : MvpUserControl<EmployeesViewModel>, IEmployeesView
    {
        public event EventHandler DisplayAllEmployees;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.DisplayAllEmployees?.Invoke(null, null);

            this.EmployeesGridView.DataSource = this.Model.AllEmployees;
            this.EmployeesGridView.DataBind();
        }
    }
}