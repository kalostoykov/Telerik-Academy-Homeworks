using Homework.Employees.Presenters.Contracts;
using Homework.Employees.ViewModels;
using Homework.Employees.Views;
using System;
using WebFormsMvp;
using WebFormsMvp.Web;
using Homework.Employees.EventsArgs;

namespace Homework.WebFormsClient
{
    [PresenterBinding(typeof(IEmployeeDetailsPresenter))]
    public partial class EmployeeDetails : MvpPage<EmployeeDetailsViewModel>, IEmployeeDetailsView
    {
        public event EventHandler<DisplayEmployeeDetailsEventArgs> DisplayEmployeeDetails;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Request.UrlReferrer != null)
            {
                var previousLocation = this.Request.UrlReferrer.AbsoluteUri;
                this.ButtonBack.HRef = previousLocation;
            }

            var requestedEmployeeId = this.Request.Params["id"];

            var displayEmployeeDetailsEventArgs = new DisplayEmployeeDetailsEventArgs(requestedEmployeeId);
            this.DisplayEmployeeDetails(null, displayEmployeeDetailsEventArgs);

            this.EmployeeDetailsView.DataSource = this.Model.EmployeesWithId;
            this.EmployeeDetailsView.DataBind();
        }
    }
}