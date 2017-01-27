using Homework.NamePrinter.Models;
using Homework.NamePrinter.Presenters;
using Homework.NamePrinter.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsMvp;
using WebFormsMvp.Web;
using Homework.NamePrinter.EventsArgs;
using System.Web.UI.HtmlControls;

namespace Homework.NamePrinterWebFormsClient.CustomControls
{
    [PresenterBinding(typeof (NamePrinterPresenter))]
    public partial class NamePrinterUserControl : MvpUserControl<NamePrinterViewModel>, INamePrinterView
    {
        public event EventHandler<NamePrinterEventArgs> PrintName;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            string enteredName = this.Server.HtmlEncode(this.TextBoxName.Text);

            var args = new NamePrinterEventArgs(enteredName);

            this.PrintName(this, args);


        }
    }
}